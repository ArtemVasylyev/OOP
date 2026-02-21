using System;
using System.Diagnostics;

namespace AddressApp
{
    public class PostalAddress
    {

        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string ZipCode { get; set; }

        public static int ActiveAddressesCount { get; private set; } = 0;

        public PostalAddress()
        {
            Country = "Україна";
            City = "Не вказано";
            Street = "Не вказано";
            Building = "Не вказано";
            ZipCode = "00000";
            ActiveAddressesCount++;
        }
        public PostalAddress(string city, string street, string building)
        {
            Country = "Україна";
            City = city;
            Street = street;
            Building = building;
            ZipCode = "00000";
            ActiveAddressesCount++;
        }
        public PostalAddress(string country, string city, string street, string building, string zipCode)
        {
            Country = country;
            City = city;
            Street = street;
            Building = building;
            ZipCode = zipCode;
            ActiveAddressesCount++;
        }
        ~PostalAddress()
        {
            ActiveAddressesCount--;
            Debug.WriteLine("Об'єкт PostalAddress було знищено збирачем сміття.");
        }
        public void UpdateAddress(string newStreet, string newBuilding)
        {
            Street = newStreet;
            Building = newBuilding;
        }
        public void UpdateAddress(string newCity, string newStreet, string newBuilding, string newZipCode)
        {
            City = newCity;
            Street = newStreet;
            Building = newBuilding;
            ZipCode = newZipCode;
        }
        public override string ToString()
        {
            return $"{ZipCode}, {Country}, м. {City}, вул. {Street}, буд. {Building}";
        }
    }
}