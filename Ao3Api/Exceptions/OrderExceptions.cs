﻿ namespace Ao3Api.Exceptions
{
    public static class OrderExceptions
    {
        public static void PizzaTastesExceedLimit()
        {
            throw new HttpResponseException
            {
                Status = 422,
                Value = "Uma das pizzas do pedido possui mais de 2 sabores"
            };
        }

        public static void CustomerOrAddressNotFound()
        {
            throw new HttpResponseException
            {
                Status = 422,
                Value = "O cliente não foi encontrado na base e não informou dados de entrega"
            };
        }
    }
}