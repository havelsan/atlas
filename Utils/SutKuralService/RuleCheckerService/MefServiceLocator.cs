﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

using Microsoft.Practices.ServiceLocation;
using RuleCheckerService;
using ServiceTestConsole;

namespace RuleCheckerService
{
	public class MefServiceLocator : ServiceLocatorImplBase
	{
		private ExportProvider provider;

		public MefServiceLocator(ExportProvider provider)
		{
			this.provider = provider;
		}

		protected override object DoGetInstance(Type serviceType, string key)
		{
			if (key == null)
			{
				key = AttributedModelServices.GetContractName(serviceType);
			}

			IEnumerable<Lazy<object>> exports = provider.GetExports<object>(key);

			if (exports.Any())
			{
				return exports.First().Value;
			}

			throw new ActivationException(string.Format(RuleCheckStrings.CannotLocateInstancesOfContract, key));
		}

		protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
		{
			var exports = provider.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
			return exports;
		}
	}
}