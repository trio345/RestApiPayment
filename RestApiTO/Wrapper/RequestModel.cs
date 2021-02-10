using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiTO.Wrapper
{
    public class RequestModel<AttributeModel>
    {

        public RequestModel (AttributeModel data)
        {
            Data = data;
        }
        public AttributeModel Data { get; set; }
    }

    public class AttributeModel<T>
    {
        public AttributeModel()
        {

        }
        public AttributeModel(T data)
        {
            Attributes = data;
        }

        public T Attributes { get; set; }
    }
}
