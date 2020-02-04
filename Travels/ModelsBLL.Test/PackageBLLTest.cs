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

namespace ModelsBLL.Test
{
    public class PackageBLLTest
    {
        [Fact]
        public void GetPackagesWithAllPackages()
        {
            var context = new Mock<ISalesContext>();
            var packageBLL = new PackageBLL(context.Object);

            var packagesFake = new List<Package>() {
                new Package(),
                new Package(),
                new Package()
            };

            var packagesMock = createDbSetMock<Package>(packagesFake);

            context.Setup(x => x.Packages).Returns(packagesMock.Object);

            List<PackageDTO> list = packageBLL.GetPackages("");

            Assert.Equal((int)3, list.Count);
        }

        [Fact]
        public void GetPackagesWithIncorrectDescriptionThatReturnEmptyPackages()
        {
            var context = new Mock<ISalesContext>();
            var packageBLL = new PackageBLL(context.Object);

            var emptyFake = new List<Package> { };

            var packagesMock = createDbSetMock<Package>(emptyFake);

            context.Setup(x => x.Packages).Returns(packagesMock.Object);

            List<PackageDTO> list = packageBLL.GetPackages("za");

            Assert.Empty(list);
        }

        [Fact]
        public void GetPackageWithDescriptionAsMarDelPlata()
        {
            var context = new Mock<ISalesContext>();
            var packageBLL = new PackageBLL(context.Object);

            var mdqFake = new List<Package> {
                new Package {
                    PackageId = 1,
                    Description = "Mar del plata",
                    PackageItems = new List<PackageItem> { }
                }
            };

            var packageMock = createDbSetMock<Package>(mdqFake);

            context.Setup(x => x.Packages).Returns(packageMock.Object);

            PackageItemDTO package = packageBLL.GetPackage(1);

            Assert.Equal((string)"Mar del plata", package.Description);
        }

        [Fact]
        public void GetPackageWithIncorrectIdThatReturnEmptyPackage()
        {
            var context = new Mock<ISalesContext>();
            var packageBLL = new PackageBLL(context.Object);

            var nullFake = new List<Package>();

            var packageMock = createDbSetMock<Package>(nullFake);

            context.Setup(x => x.Packages).Returns(packageMock.Object);

            PackageItemDTO package = packageBLL.GetPackage(7);

            Assert.Null(package);
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
