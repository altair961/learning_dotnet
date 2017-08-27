using Core.Common;

namespace CarRental.Client.Entities
{
    public class Car : ObjectBase
    {
        private int carId;
        private string description;
        private string color;
        private int year;
        private decimal rentalPrice;
        private bool currentlyRented;

        public int CarId
        {
            get
            {
                return carId;
            }
            set
            {
                carId = value;
                OnPropertyChanged("CarId");
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public decimal RentalPrice
        {
            get
            {
                return rentalPrice;
            }
            set
            {
                rentalPrice = value;
                OnPropertyChanged("RentalPrice");
            }
        }

        public bool CurrentlyRented
        {
            get
            {
                return currentlyRented;
            }
            set
            {
                currentlyRented = value;
                OnPropertyChanged("CurrentlyRented");
            }
        }
    }
}
