using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVVM4Maui.Sorting
{
    public static class SortData
    {
        public static void SortList<T>(ref List<T> lista, SortingOrder sort, string propertyToOrder)
        {
            if (!string.IsNullOrEmpty(propertyToOrder) && lista != null && lista.Count > 0)
            {
                Type t = lista[0].GetType();

                if (sort == SortingOrder.Ascendant)
                {
                    lista = lista.OrderBy(
                        a => t.InvokeMember(
                            propertyToOrder
                            , System.Reflection.BindingFlags.GetProperty
                            , null
                            , a
                            , null
                        )
                    ).ToList();
                }
                else
                {
                    lista = lista.OrderByDescending(
                        a => t.InvokeMember(
                            propertyToOrder
                            , System.Reflection.BindingFlags.GetProperty
                            , null
                            , a
                            , null
                        )
                    ).ToList();
                }
            }
        }
    }
}
