using System;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using FluentValidation;
using Core.Utilities;
using Core.Utilities.Messages;
using System.Linq;
using Core.CrossCuttingConcerns.Validation.FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
	public class ValidationAspect:MethodInterception
	{
		private Type _validatorType;
		public ValidationAspect(Type validatorType)
		{
			if(!typeof(IValidator).IsAssignableFrom(validatorType))
			{
				throw new Exception(AspectMessages.WrongValidationType);
			}
			_validatorType = validatorType;
		}

        protected override void OnBefore(IInvocation invocation)
        {
			var validator = (IValidator)Activator.CreateInstance(_validatorType);
			var entityType = _validatorType.BaseType.GetGenericArguments()[0];
			var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

			foreach(var entity in entities)
			{
				ValidationTool.Validate(validator, entity);
			}
			// this might work too?
			// var entityType = _validatorType.BaseType.GetGenericArguments().FirstOrDefault(arg => arg == invocation.TargetType);
			// null check entityType
        }
    }
	
}

