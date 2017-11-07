﻿/*************************************************************
 *          Project: NetCoreCMS                              *
 *              Web: http://dotnetcorecms.org                *
 *           Author: OnnoRokom Software Ltd.                 *
 *          Website: www.onnorokomsoftware.com               *
 *            Email: info@onnorokomsoftware.com              *
 *        Copyright: OnnoRokom Software Ltd.                 *
 *          License: BSD-3-Clause                            *
 *************************************************************/

using NetCoreCMS.Framework.Core.Auth;
using System;
//[assembly: CLSCompliant(true)]
namespace NetCoreCMS.Framework.Core.Mvc.Attributes
{
    /// <summary>
    /// NetCoreCMS default authorization attribute for controller and action.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class NccAuthorize : Attribute
    {
        private string _handlerClassName;
        private string _requirement;
        private string _values;
        private string[] _requirementList;
        private string[] _valueList;

        public string[] RequirementList { get => _requirementList; set => _requirementList = value; }
        public string[] ValueList { get => _valueList; set => _valueList = value; }

        public NccAuthorize(string HandlerClassName = "NccAuthRequireHandler")
        {
            _handlerClassName = HandlerClassName;
        }

        /// <summary>
        /// Constracture for AuthRequirement
        /// <param name="PolicyHandler">Which handler will handle this requirement. You can implement your own Authorization Handler</param>
        /// <param name="Requirement">Requirement name. Use NccAuthRequirementName class constants.</param>
        /// </summary>        
        public NccAuthorize(string Requirement, string PolicyHandler = "NccAuthRequireHandler")
        {
            _handlerClassName = PolicyHandler;
            _requirement = Requirement;
        }

        /// <summary>
        /// Use requirement name with value. If requirement name is Roles then pass roles coma seperated role names.
        /// </summary>
        /// <param name="PolicyHandler">Which handler will handle this requirement. You can implement your own Authorization Handler</param>
        /// <param name="Requirement">Requirement name</param>
        /// <param name="Values">If value is require use appropriate coma seperated values.</param>
        public NccAuthorize(string Requirement, string Values, string PolicyHandler = "NccAuthRequireHandler")
        {
            _handlerClassName = PolicyHandler;
            _requirement = Requirement;
            _values = Values;
        }  
        
        public string GetHandlerClassName()
        {
            return _handlerClassName;
        }

        public string GetRequirement()
        {
            return _requirement;
        }

        public string GetValues()
        {
            return _values;
        }
    }
}