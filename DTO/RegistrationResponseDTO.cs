﻿namespace AspNetCoreIdentityWebApi.DTO
{
    public class RegistrationResponseDTO
    {
        public bool Success {  get;set; }
        public string Message {  get;set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
