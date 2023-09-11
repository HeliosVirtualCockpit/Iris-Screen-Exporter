using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iris.Common
{
    public enum SocketErrorCodes
    {
        InterruptedFunctionCall = 10004,
        PermissionDenied = 10013,
        BadAddress = 10014,
        InvalidArgument = 10022,
        TooManyOpenFiles = 10024,
        ResourceTemporarilyUnavailable = 10035,
        OperationNowInProgress = 10036,
        OperationAlreadyInProgress = 10037,
        SocketOperationOnNonSocket = 10038,
        DestinationAddressRequired = 10039,
        MessgeTooLong = 10040,
        WrongProtocolType = 10041,
        BadProtocolOption = 10042,
        ProtocolNotSupported = 10043,
        SocketTypeNotSupported = 10044,
        OperationNotSupported = 10045,
        ProtocolFamilyNotSupported = 10046,
        AddressFamilyNotSupported = 10047,
        AddressInUse = 10048,
        AddressNotAvailable = 10049,
        NetworkIsDown = 10050,
        NetworkIsUnreachable = 10051,
        NetworkReset = 10052,
        ConnectionAborted = 10053,
        ConnectionResetByPeer = 10054,
        NoBufferSpaceAvailable = 10055,
        AlreadyConnected = 10056,
        NotConnected = 10057,
        CannotSendAfterShutdown = 10058,
        ConnectionTimedOut = 10060,
        ConnectionRefused = 10061,
        HostIsDown = 10064,
        HostUnreachable = 10065,
        TooManyProcesses = 10067,
        NetworkSubsystemIsUnavailable = 10091,
        UnsupportedVersion = 10092,
        NotInitialized = 10093,
        ShutdownInProgress = 10101,
        ClassTypeNotFound = 10109,
        HostNotFound = 11001,
        HostNotFoundTryAgain = 11002,
        NonRecoverableError = 11003,
        NoDataOfRequestedType = 11004
    }

}
