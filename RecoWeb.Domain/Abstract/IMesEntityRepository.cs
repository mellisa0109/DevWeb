using System;
using System.Collections.Generic;
using RecoWeb.Domain.Concrete;
using System.Collections;
using Dapper;

namespace RecoWeb.Domain.Abstract
{
    public interface IMesEntityRepository
    {

        //ObjectResult CallProcudure<T>(string precedureName, ObjectParameter[] parameters);
        IList<T> CallProcudureToReturnList<T>(string procedureName, DynamicParameters parameters);

        int CallProcudureToReturnMessage(string precedureName, DynamicParameters parameters);
    }
}
