﻿using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.DataProtection
{
    public class DataProtection : IDataProtection
    {
        private readonly IDataProtector _protector;

        public DataProtection(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("security");
        }

        public string Protect(string text)
        {
            return _protector.Protect(text);
        }

        public string UnProtected(string protectedText)
        {
            return _protector.Unprotect(protectedText);
        }
    }
}
