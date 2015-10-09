﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplicationConverters
{
    public class PassThroughConverter : IMultiValueConverter 
    {
        public Object Convert(Object[] values, Type targetType,
            Object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        public Object[] ConvertBack(Object value, Type[] targetTypes,
            Object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
