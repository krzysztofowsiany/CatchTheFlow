﻿namespace Sound.Application.Events
{
    public class WorkStopped
    {
        public string Value { get; }
        public WorkStopped(string value)
        {
            Value = value;
        }
    }
}