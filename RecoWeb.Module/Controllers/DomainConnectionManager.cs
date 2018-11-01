using Dapper;
using RecoWeb.Domain.Abstract;
//using RecoWeb.Module;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RecoWeb.Module.Controllers
{
    public class DomainConnectionManager : IDisposable
    {
        private IMesEntityRepository repository;
        public DomainConnectionManager(IMesEntityRepository repositoryParam)
        {
            repository = repositoryParam;
        }

        public void Dispose()
        {
            repository = null;
        }

        /// <summary>
        /// DB콜→SELECT 반환
        /// </summary>
        public IList<T> GetEntityToList<T>(string procedureName, DynamicParameters parameters)
        {
            var resultData = repository.CallProcudureToReturnList<T>(procedureName, parameters);
            return resultData;
            //var returnList = HMTLHelperExtensions.ToList(resultData.AsQueryable());
            //return returnList;
        }

        /// <summary>
        /// DB콜→Output 반환
        /// </summary>
        public int GetEntityResult(string procedureName, DynamicParameters parameters)
        {
            int result = repository.CallProcudureToReturnMessage(procedureName, parameters);
            return result;
        }
    }
}