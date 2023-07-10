using Domain.Entities;

namespace Domain.DomainServices
{
    public static class HomePriceDomainService
    {
        public static decimal GetPriceByHome(ViviendasEntity vivienda, BarrioEntity barrio, 
            Dictionary<string, AniadidoEntity> aniadidos)
        {
            decimal price = barrio.CosteM2 * vivienda.M2;

            foreach(var aniadidoVivienda in vivienda.Aniadidos)
            {
                AniadidoEntity? priceAniadido = aniadidos.FirstOrDefault(x => x.Key == aniadidoVivienda.Key).Value;

                if (priceAniadido.PrecioM2 is not 0) 
                {
                    price = price + priceAniadido.PrecioM2 * aniadidoVivienda.Value;
                }
                else
                {
                    price = price + priceAniadido.Precio;
                }
            }

            return price;
        }
    }
}
