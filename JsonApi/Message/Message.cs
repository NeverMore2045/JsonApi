﻿namespace JsonApi.Message
{
    public class Message
    {
        // класс сообщения статуса сервера
        public class ServerStatus
        {
            public string Status { get; set; }
            public DateTime DateTime { get; set; }
            public string HostName { get; set; }
            public ServerStatus(string status, DateTime dateTime, string hostName)
            {
                Status = status;
                DateTime = dateTime;
                HostName = hostName;
            }
        }
        public class Methods
        {
            public string methNameUrl { get; set; }
            public string Description { get; set; }
            public Methods(string methNameUrl, string description)
            {
                this.methNameUrl = methNameUrl;
                Description = description;
            }
        }
    }
}

