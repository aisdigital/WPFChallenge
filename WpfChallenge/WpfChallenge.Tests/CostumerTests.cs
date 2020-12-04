using System;
using System.Collections.Generic;
using System.Text;
using WpfChallenge;
using WpfChallenge.Model;
using WpfChallenge.Controller;
using Xunit;

namespace WpfChallenge.Tests
{
    public class CostumerTests
    {
        [Fact]
        public void new_costumer()
        {
            //Arrange
            Costumer costumerExpected = new Costumer
                {
                Name = "Name Teste",
                Email = "email@test.com",
                Phone = "(61) 99999-9999",
                Address = "Address Teste"
                };

            //Act
            CostumerController controller = new CostumerController();
            controller.saveCostumer(
                new Costumer
                {
                    Name = "Name Teste",
                    Email = "email@test.com",
                    Phone = "(61) 99999-9999",
                    Address = "Address Teste"
                }
                );

            List<Costumer> allCostumers = controller.getAllCostumer();
            Costumer costumerActual = allCostumers[allCostumers.Count - 1];

            //Assert
            Assert.Equal(costumerExpected, costumerActual);

            //EndTest
            controller.deleteCostumer(int.Parse(costumerActual.id));
        }

        [Fact]
        public void edit_costumer()
        {
            //Arrange
            Costumer costumerExpected = new Costumer
            {
                Name = "Name Teste Editado",
                Email = "email@test.com",
                Phone = "(61) 99999-9999",
                Address = "Address Teste"
            };

            //Act
            CostumerController controller = new CostumerController();
            controller.saveCostumer(
                new Costumer
                {
                    Name = "Name Teste",
                    Email = "email@test.com",
                    Phone = "(61) 99999-9999",
                    Address = "Address Teste"
                }
                );

            List<Costumer> allCostumers = controller.getAllCostumer();
            Costumer costumerActual = allCostumers[allCostumers.Count - 1];

            //Action Edit
            costumerActual.Name = "Name Teste Editado";
            controller.editCostumer(costumerActual);

            //Assert
            Assert.Equal(costumerExpected, costumerActual);

            //EndTest
            controller.deleteCostumer(int.Parse(costumerActual.id));
        }



    }
}
