﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetDemo.Utility
{
    public static class SD  
    {
        public const string Role_User_Cust = "Customer";
        public const string Role_Employee = "Employee";
        public const string Role_User_Comp = "Company";
        public const string Role_Admin = "Admin";

        public const string StatusPending = "Pending";
        public const string StatusInProcess = "Processing";
        public const string StatusReady = "Ready";
        public const string StatusCancelled = "Cancelled";
        public const string StatusCompleted = "Completed";

        public const string PaymentStatusPending = "Pending";
        public const string PaymentStatusApproved = "Approved";
        public const string PaymentStatusDelayedPayment = "ApprovedForDelayedPayment";
        public const string PaymentStatusRejected = "Rejected";
    }
}
