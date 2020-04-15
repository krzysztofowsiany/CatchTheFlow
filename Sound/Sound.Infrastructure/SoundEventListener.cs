﻿using System;
using CQRSLib;
using EventBus;
using Sound.Application.Commands;
using Sound.Application.Views;
using Sound.Application.Events;

namespace Sound.Infrastructure
{
    public class SoundEventListener
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IEventRepository _eventRepository;

        public SoundEventListener(
            IEventBus eventBus, 
            ICommandBus commandBus,
            IEventRepository eventRepository)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _eventRepository = eventRepository;
            
            SubscribeToWorkStopped();
            SubscribeToWorkStarted();
        }

        private void SubscribeToWorkStarted()
        {
            _eventBus.Subscribe<WorkStarted>(@event =>
            {
                var view = new SoundWorkInformationView(_eventRepository);

                _commandBus.Send(new StartPlayCommand
                {
                    Timestamp = DateTime.UtcNow,
                    Sound = view.Sound
                });
            });
        }

        private void SubscribeToWorkStopped()
        {
            _eventBus.Subscribe<WorkStopped>(@event =>
            {
                var view = new WorkStopTimeView(_eventRepository);

                _commandBus.Send(new StopPlayCommand
                {
                    Timestamp = DateTime.UtcNow,
                    StopTime = view.StopTime
                });
            });
        }
    }
}