using System;
using Xunit;
using Models;

namespace Testing
{
    public class UnitTest1
    {
       /// <summary>
        /// Will test if the city property will set with valid data
        /// valid data - anything with letters only
        /// </summary>
        [Fact] //Fact is a testcase that doesn't have any parameters and will only run once
        public void NameShouldSetValidData()
        {
            //Arrange
           Customer _customerTest = new Customer();
            string _name = "TestName";

            //Act
            _customerTest.Name = _name;

            //Assert
            Assert.NotNull(_customerTest.Name);
            Assert.Equal(_customerTest.Name, _name);
        }

        /// <summary>
        /// Will test if city property gives exception if given invalid data
        /// invalid data - When you add anything beyond letters
        /// </summary>
        [Theory] //Change to Theory to create a parametrize test case
        [InlineData("B*bby")] //InlineData will be the data being passed to the parameter of this method to be tested on
        [InlineData("17458")] //You can add more
        [InlineData("")]
        public void NameShouldFailIfSetWithInvalidData(string p_input)
        {
            //Arrange
           Customer _customerTest = new Customer();
        

            //Act & Assert
            //Throws method will only pass if the code you did will give some sort of an exception
            Assert.Throws<Exception>(() => _customerTest.Name = p_input);
        }
    }
}