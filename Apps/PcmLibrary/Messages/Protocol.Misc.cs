﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PcmHacking
{
    public partial class Protocol
    {
        /// <summary>
        /// Tell the bus that a test device is present.
        /// </summary>
        public Message CreateTestDevicePresentNotification()
        {
            byte[] bytes = new byte[] { Priority.Physical0High, DeviceId.Broadcast, DeviceId.Tool, Mode.TestDevicePresent };
            return new Message(bytes);
        }

        /// <summary>
        /// Create a broadcast message telling the PCM to clear DTCs
        /// </summary>
        public Message CreateClearDTCs()
        {
            byte[] bytes = new byte[] { Priority.Functional0, 0x6A, DeviceId.Tool, Mode.ClearDTCs };
            return new Message(bytes);
        }

        /// <summary>
        /// A successfull response seen after the Clear DTCs message
        /// </summary>
        public Message CreateClearDTCsOK()
        {
            byte[] bytes = new byte[] { 0x48, 0x6B, DeviceId.Pcm, Mode.ClearDTCs + Mode.Response };
            return new Message(bytes);
        }

        /// <summary>
        /// Create a broadcast message telling all devices to disable normal message transmission (disable chatter)
        /// </summary>
        public Message CreateDisableNormalMessageTransmission()
        {
            byte[] Bytes = new byte[] { Priority.Physical0, DeviceId.Broadcast, DeviceId.Tool, Mode.SilenceBus, SubMode.Null };
            return new Message(Bytes);
        }

        /// <summary>
        /// Create a broadcast message telling all devices to disable normal message transmission (disable chatter)
        /// </summary>
        public Message CreateDisableNormalMessageTransmissionOK()
        {
            byte[] bytes = new byte[] { Priority.Physical0, DeviceId.Tool, DeviceId.Pcm, Mode.SilenceBus + Mode.Response, SubMode.Null };
            return new Message(bytes);
        }

        /// <summary>
        /// Create a broadcast message telling all devices to clear their DTCs
        /// </summary>
        public Message ClearDTCs()
        {
            byte[] bytes = new byte[] { Priority.Functional0, 0x6A, DeviceId.Tool, Mode.ClearDTCs };
            return new Message(bytes);
        }

        /// <summary>
        /// PCM Response to Clear DTCs
        /// </summary>
        public Message ClearDTCsOK()
        {
            byte[] bytes = new byte[] { Priority.Functional0Low, 0x6B, DeviceId.Pcm, Mode.ClearDTCs + Mode.Response };
            return new Message(bytes);
        }

        public Response<bool> ParseRecoveryModeBroadcast(Message message)
        {
            return this.DoSimpleValidation(message, 0x6C, 0x62, 0x01);
        }        
    }
}