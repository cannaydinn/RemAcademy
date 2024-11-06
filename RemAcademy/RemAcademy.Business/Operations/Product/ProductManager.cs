using Microsoft.EntityFrameworkCore;
using RemAcademy.Business.Operations.Product.Dtos;
using RemAcademy.Business.Types;
using RemAcademy.Data.Entities;
using RemAcademy.Data.Repositories;
using RemAcademy.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.Product
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductEntity> _repository;

        public ProductManager(IUnitOfWork unitOfWork, IRepository<ProductEntity> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public async Task<ServiceMessage> AddProduct(AddProductDto product)
        {
            var hasCourseName = _repository.GetAll(x => x.CourseName.ToLower() == product.CourseName.ToLower()).Any();
            if (hasCourseName) 
            {
                return new ServiceMessage
                {
                    IsSucceed = false, 
                    Message = "Kurs adı özelliği zaten bulunuyor !!"
                };
            }
            
            var hasClassGrade = _repository.GetAll(x => x.ClassGrade.ToLower() == product.ClassGrade.ToLower()).Any();
            if (hasClassGrade)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Sınıf özelliği zaten bulunuyor !!"
                };
            }

            var productEntity = new ProductEntity
            {
                CourseName = product.CourseName,
                ClassGrade = product.ClassGrade,
            };

            _repository.Add(productEntity);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Özellik kaydı sırasında hata oluştu");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public async Task<ServiceMessage> ChangeCourseName(int id, string changeBy)
        {
            var product = _repository.GetById(id);

            if (product is null)
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Id ile eşleşen ürün bulunamadı"
                };
            }
            product.CourseName = changeBy;
            _repository.Update(product);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ders ismi değiştirilirken bir hata oluştu");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }

        public async Task<ServiceMessage> DeleteProduct(int id)
        {
            var product = _repository.GetById(id);
            if (product is null) 
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Silinmek istenen ürün bulunamadı!!!"
                };
            }

            _repository.Delete(product);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception("Ürün silinirken hata oluştu!!!");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            }; 
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var product = await _repository.GetAll(x => x.Id == id)
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    CourseName = x.CourseName,
                    ClassGrade = x.ClassGrade,
                }).FirstOrDefaultAsync();

            return product;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _repository.GetAll()
                .Select(x => new ProductDto
                {
                    Id = x.Id,
                    CourseName = x.CourseName,
                    ClassGrade = x.ClassGrade,
                }).ToListAsync();

            return products;
        }

        public async Task<ServiceMessage> UpdateProduct(UpdateProductDto product)
        {
            var productEntitiy = _repository.GetById(product.Id);
            if (productEntitiy is null) 
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Ürün Bulunamadı",
                };
            }

            await _unitOfWork.BeginTransaction();
            productEntitiy.CourseName = product.CourseName;
            productEntitiy.ClassGrade = product.ClassGrade;

            _repository.Update(productEntitiy);
            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception("Ürün Bilgisi güncellenirken hata ile karşılaşıldı");
            }

            return new ServiceMessage
            {
                IsSucceed = true
            };
        }
    }
}
