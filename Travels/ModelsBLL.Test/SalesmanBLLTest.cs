using System;
using System.Collections.Generic;
using System.Text;
using ModelsBLL;
using ModelsDTO;
using Xunit;
using Moq;
using ModelsDAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Enums;

namespace ModelsBLL.Test
{
    public class SalesmanBLLTest
    {
        [Fact]
        public void CalculatewithInvalidOperationException()
        {
            var context = new Mock<ISalesContext>();
            var salesmanBLL = new SalesmanBLL(context.Object);

            var calculateMock = new Mock<DbSet<Package>>();

            context.Setup(x => x.Packages).Returns(calculateMock.Object);

            var result = Assert.Throws<InvalidOperationException>(() => salesmanBLL.Calculate(4, 3, 20, new List<int>()));

            Assert.Equal("Error! you must enter valid data", result.Message);
        }

        [Fact]
        public void CalculateWithValidCommission()
        {
            var context = new Mock<ISalesContext>();
            var salesmanBLL = new SalesmanBLL(context.Object);

            var doubleFake = new List<Package> {
                new Package{ PackageId = 1 ,
                    PackageItems = new List<PackageItem>{
                        new PackageItem {
                            Item = new Item {Category = 0, Price = 34, Type = (int)ItemType.AirplaneTicket}
                        },
                        new PackageItem {
                            Item = new Item {Category = 0, Price = 34, Type = (int)ItemType.Hotel}
                        },
                        new PackageItem {
                            Item = new Item {Category = 0, Price = 34, Type = (int)ItemType.Carrental}
                        },
                    }
                },
                new Package{ PackageId = 2,
                PackageItems = new List<PackageItem>{
                        new PackageItem {
                            Item = new Item {Category = 0, Price = 34, Type = (int)ItemType.AirplaneTicket}
                        },
                        new PackageItem {
                            Item = new Item {Category = 0, Price = 34, Type = (int)ItemType.Hotel}
                        },
                        new PackageItem {
                            Item = new Item {Category = 0, Price = 34, Type = (int)ItemType.Carrental}
                        },
                    }
                }
            };

            var calculateMock = createDbSetMock<Package>(doubleFake);

            context.Setup(x => x.Packages).Returns(calculateMock.Object);

            var result = salesmanBLL.Calculate(2, 3, 5, new List<int> { 1, 2 });

            Assert.IsType<double>(result);
        }

        private Mock<DbSet<T>> createDbSetMock<T>(List<T> listFake) where T : class
        {
            var list = listFake.AsQueryable();

            var dbSetMock = new Mock<DbSet<T>>();
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(list.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(list.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(list.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(listFake.GetEnumerator());

            return dbSetMock;
        }
    }
}
