using Enums;
using ModelsDAL;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ModelsBLL
{
    public class SalesmanBLL : ISalesmanBLL
    {
        private readonly ISalesContext _ctx;

        public SalesmanBLL(ISalesContext ctx)
        {
            _ctx = ctx;
        }

        public double Calculate(int cType, int passengers, int nights, List<int> idsPackages)
        {
            if (!Enum.IsDefined(typeof(ClientType), cType) || passengers <= 0 || passengers > 10 ||
                nights <= 0 || nights > 60 || !idsPackages.Any())
                throw new InvalidOperationException("Error! you must enter valid data");

            var packages = _ctx.Packages.Where(y => idsPackages.Contains(y.PackageId));

            if (packages == null || !packages.Any())
                throw new InvalidOperationException("Error! you must enter valid data");

            double amount = 0;

            if (cType == (int)ClientType.Corporate)
            {
                foreach (var package in packages)
                {
                    amount += package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.Hotel).Item.Price * nights;
                    amount += package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.Carrental).Item.Price * nights;
                    amount += package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.AirplaneTicket).Item.Price * 4 * passengers;
                }

                amount = amount * passengers * 0.1;
            }
            else
            {
                foreach (var package in packages)
                {
                    var hotelPrice = package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.Hotel).Item.Price;
                    amount += nights < 6 ? hotelPrice * 0.5 : hotelPrice * nights % 6;

                    var rentalPrice = package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.Carrental).Item.Price;
                    var category = package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.Carrental).Item.Category;
                    amount += (rentalPrice * 0.01) + 100 * category;

                    amount += package.PackageItems.FirstOrDefault(x => x.Item.Type == (int)ItemType.AirplaneTicket).Item.Price * 2 * passengers * 0.1;
                }

                amount *= passengers;
            }
            return amount;
        }
    }
}
