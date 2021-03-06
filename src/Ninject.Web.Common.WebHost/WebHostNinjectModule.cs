﻿// -------------------------------------------------------------------------------------------------
// <copyright file="WebHostNinjectModule.cs" company="Ninject Project Contributors">
//   Copyright (c) 2010-2011 bbv Software Services AG.
//   Copyright (c) 2011-2017 Ninject Project Contributors. All rights reserved.
//
//   Dual-licensed under the Apache License, Version 2.0, and the Microsoft Public License (Ms-PL).
//   You may not use this file except in compliance with one of the Licenses.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//   or
//       http://www.microsoft.com/opensource/licenses.mspx
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace Ninject.Web.Common.WebHost
{
    using System.Web;
    using System.Web.Routing;

    /// <summary>
    /// Defines the bindings that are common for all ASP.NET web extensions.
    /// </summary>
    public class WebHostNinjectModule : GlobalKernelRegistrationModule<OnePerRequestHttpModule>
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            base.Load();
            this.Bind<RouteCollection>().ToConstant(RouteTable.Routes);
            this.Bind<HttpContextBase>().ToMethod(ctx => new HttpContextWrapper(HttpContext.Current)).InTransientScope();
            this.Bind<HttpContext>().ToMethod(ctx => HttpContext.Current).InTransientScope();
        }
    }
}