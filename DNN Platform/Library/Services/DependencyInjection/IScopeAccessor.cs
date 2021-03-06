﻿using DotNetNuke.Common.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Web;

namespace DotNetNuke.Services.DependencyInjection
{
    public interface IScopeAccessor
    {
        IServiceScope GetScope();
    }

    public class ScopeAccessor : IScopeAccessor
    {
        private static Func<IDictionary> fallbackGetContextItems = () => HttpContext.Current?.Items;

        private Func<IDictionary> _getContextItems;

        public ScopeAccessor()
        {
            _getContextItems = fallbackGetContextItems;
        }

        public IServiceScope GetScope()
        {
            return HttpContextDependencyInjectionExtensions.GetScope(_getContextItems());
        }

        internal void SetContextItemsFunc(Func<IDictionary> getContextItems)
        {
            _getContextItems = getContextItems ?? fallbackGetContextItems;
        }
    }
}
