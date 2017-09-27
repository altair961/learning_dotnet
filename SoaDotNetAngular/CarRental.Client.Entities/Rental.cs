using Core.Common.Core;
using System;

namespace CarRental.Client.Entities
{
    public class Rental : ObjectBase
    {
        private int rentalId;
        private int accountId;
        private int carId;
        private DateTime dateRented;
        private DateTime dateDue;
        private DateTime? dateReturned;

        public int RentalId
        {
            get { return rentalId; }
            set
            {
                if(rentalId != value)
                {
                    rentalId = value;
                    OnPropertyChanged(() => rentalId);
                }                
            }
        }
        public int AccountId
        {
            get { return accountId; }
            set
            {
                if(accountId != value)
                {
                    accountId = value;
                    OnPropertyChanged(() => rentalId);
                }
            }
        }
        public int CarId
        {
            get { return carId; }
            set
            {
                if(carId != value)
                {
                    carId = value;
                    OnPropertyChanged(() => carId);
                }
            }
        }
        public DateTime DateRented
        {
            get { return dateRented; }
            set
            {
                if(dateRented != value)
                {
                    dateRented = value;
                    OnPropertyChanged(() => dateRented);
                }
            }
        }
        public DateTime DateDue
        {
            get { return dateDue; }
            set
            {
                if(dateDue != value)
                {
                    dateDue = value;
                    OnPropertyChanged(() => dateDue);
                }
            }
        }
        public DateTime? DateReturned
        {
            get { return dateReturned; }
            set
            {
                if(dateReturned != value)
                {
                    dateReturned = value;
                    OnPropertyChanged(() => dateReturned);
                }
            }
        }
    }
}
