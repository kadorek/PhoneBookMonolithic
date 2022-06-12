﻿namespace PhoneBookMonolithic.Models
{
    public class CommunicationInfo
    {
        public CommunicationInfoType InfoType { get; set; }
        public string Value { get; set; }
    }

    public enum CommunicationInfoType
    {
        Adress, 
        Email,
        Phone,
        Location
    }
}
