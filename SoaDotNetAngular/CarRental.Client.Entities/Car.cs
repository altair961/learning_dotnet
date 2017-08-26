namespace CarRental.Client.Entities
{
    public class Car
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
            }
        }
    }
}
