using System;

namespace Aark.SecurityHeaders.Extension.Constants
{
    public static partial class FeaturePolicyConstants
    {
        /// <summary>
        /// Feature Policy allows web developers to selectively enable, disable, and modify the behavior of certain features and APIs in the browser. It is similar to Content Security Policy but controls features instead of security behavior.
        /// </summary>
        [Flags]
        public enum HttpFeatures
        {
            /// <summary>
            /// Controls whether the current document is allowed to gather information about the acceleration of the device through the Accelerometer interface.
            /// </summary>
            Accelerometer = 1,
            /// <summary>
            /// Controls whether the current document is allowed to gather information about the amount of light in the environment around the device through the AmbientLightSensor interface.
            /// </summary>
            AmbientLightSensor = 2,
            /// <summary>
            /// Controls whether the current document is allowed to autoplay media requested through the HTMLMediaElement interface. When this policy is enabled and there were no user gestures, the Promise returned by HTMLMediaElement.play() will reject with a DOMException. The autoplay attribute on audio and video elements will be ignored.
            /// </summary>
            Autoplay = 4,
            /// <summary>
            /// Controls whether the use of the Battery Status API is allowed. When this policy is enaled, the Promise returned by Navigator.getBattery() will reject with a NotAllowedError DOMException.
            /// </summary>
            Battery = 8,
            /// <summary>
            /// Controls whether the current document is allowed to use video input devices. When this policy is enabled, the Promise returned by getUserMedia() will reject with a NotAllowedError DOMException.
            /// </summary>
            Camera = 16,
            /// <summary>
            /// Controls whether or not the current document is permitted to use the getDisplayMedia() method to capture screen contents. When this policy is enabled, the promise returned by getDisplayMedia() will reject with a NotAllowedError if permission is not obtained to capture the display's contents.
            /// </summary>
            DisplayCapture = 32,
            /// <summary>
            /// Controls whether the current document is allowed to set document.domain. When this policy is enabled, attempting to set document.domain will fail and cause a SecurityError DOMException to be be thrown.
            /// </summary>
            DocumentDomain = 64,
            /// <summary>
            /// Controls whether the current document is allowed to use the Encrypted Media Extensions API (EME). When this policy is enabled, the Promise returned by Navigator.requestMediaKeySystemAccess() will reject with a DOMException.
            /// </summary>
            EncryptedMedia = 128,
            /// <summary>
            /// Controls whether tasks should execute in frames while they're not being rendered (e.g. if an iframe is hidden or display: none).
            /// </summary>
            ExecutionWhileNotRendered = 256,
            /// <summary>
            /// Controls whether tasks should execute in frames while they're outside of the visible viewport.
            /// </summary>
            ExecutionWhileOutOfViewport = 512,
            /// <summary>
            /// Controls whether the current document is allowed to use Element.requestFullScreen(). When this policy is enabled, the returned Promise rejects with a TypeError DOMException.
            /// </summary>
            Fullscreen = 1024,
            /// <summary>
            /// Controls whether the current document is allowed to use the Geolocation Interface. When this policy is enabled, calls to getCurrentPosition() and watchPosition() will cause those functions' callbacks to be invoked with a PositionError code of PERMISSION_DENIED.
            /// </summary>
            Geolocation = 2048,
            /// <summary>
            /// Controls whether the current document is allowed to gather information about the orientation of the device through the Gyroscope interface.
            /// </summary>
            Gyroscope = 4096,
            /// <summary>
            /// Controls whether the current document is allowed to show layout animations.
            /// </summary>
            LayoutAnimations = 8192,
            /// <summary>
            /// Controls whether the current document is allowed to display images in legacy formats.
            /// </summary>
            LegacyImageFormats = 16384,
            /// <summary>
            /// Controls whether the current document is allowed to gather information about the orientation of the device through the Magnetometer interface.
            /// </summary>
            Magnetometer = 32768,
            /// <summary>
            /// Controls whether the current document is allowed to use audio input devices. When this policy is enabled, the Promise returned by MediaDevices.getUserMedia() will reject with a NotAllowedError.
            /// </summary>
            Microphone = 65536,
            /// <summary>
            /// Controls whether the current document is allowed to use the Web MIDI API. When this policy is enabled, the Promise returned by Navigator.requestMIDIAccess() will reject with a DOMException.
            /// </summary>
            Midi = 131072,
            /// <summary>
            /// Controls the availability of mechanisms that enables the page author to take control over the behavior of spatial navigation, or to cancel it outright.
            /// </summary>
            NavigationOverride = 262144,
            /// <summary>
            /// Controls whether the current document is allowed to download and display large images.
            /// </summary>
            OversizedImages = 524288,
            /// <summary>
            /// Controls whether the current document is allowed to use the Payment Request API. When this policy is enabled, the PaymentRequest() constructor will throw a SecurityError DOMException.
            /// </summary>
            Payment = 1048576,
            /// <summary>
            /// Controls whether the current document is allowed to play a video in a Picture-in-Picture mode via the corresponding API.
            /// </summary>
            PictureInPicture = 2097152,
            /// <summary>
            /// Controls whether the current document is allowed to use Web Authentication API to create, store, and retreive public-key credentials.
            /// </summary>
            PublickeyCredentials = 4194304,
            /// <summary>
            /// Controls whether the current document is allowed to play audio via any methods.
            /// </summary>
            Speaker = 8388608,
            /// <summary>
            /// Controls whether the current document is allowed to make synchronous XMLHttpRequest requests.
            /// </summary>
            SyncXhr = 16777216,
            /// <summary>
            /// Controls whether the current document is allowed to use the WebUSB API.
            /// </summary>
            Usb = 33554432,
            /// <summary>
            /// Controls whether the current document is allowed to use Wake Lock API to indicate that device should not enter power-saving mode.
            /// </summary>
            WakeLock = 67108864,
            /// <summary>
            /// Controls whether or not the current document is allowed to use the WebXR Device API to interact with a WebXR session.
            /// </summary>
            XrSpatialTracking = 134217728
        }
    }

    internal static class HttpFeaturesHelper
    {
        internal const string Accelerometer = "accelerometer";
        internal const string AmbientLightSensor = "ambient-light-sensor";
        internal const string Autoplay = "autoplay";
        internal const string Battery = "battery";
        internal const string Camera = "camera";
        internal const string DisplayCapture = "display-capture";
        internal const string DocumentDomain = "document-domain";
        internal const string EncryptedMedia = "encrypted-media";
        internal const string ExecutionWhileNotRendered = "execution-while-not-rendered";
        internal const string ExecutionWhileOutOfViewport = "execution-while-out-of-viewport";
        internal const string Fullscreen = "fullscreen";
        internal const string Geolocation = "geolocation";
        internal const string Gyroscope = "gyroscope";
        internal const string LayoutAnimations = "layout-animations";
        internal const string LegacyImageFormats = "legacy-image-formats";
        internal const string NavigationOverride = "navigation-override";
        internal const string Magnetometer = "magnetometer";
        internal const string Microphone = "microphone";
        internal const string Midi = "midi";
        internal const string OversizedImages = "oversized-images";
        internal const string Payment = "payment";
        internal const string PictureInPicture = "picture-in-picture";
        internal const string PublickeyCredentials = "publickey-credentials";
        internal const string Speaker = "speaker";
        internal const string SyncXhr = "sync-xhr";
        internal const string Usb = "usb";
        internal const string WakeLock = "wake-lock";
        internal const string XrSpatialTracking = "xr-spatial-tracking";

        public static string ToFormatedString(this FeaturePolicyConstants.HttpFeatures directive)
        {
            return directive switch
            {
                FeaturePolicyConstants.HttpFeatures.Accelerometer => Accelerometer,
                FeaturePolicyConstants.HttpFeatures.AmbientLightSensor => AmbientLightSensor,
                FeaturePolicyConstants.HttpFeatures.Autoplay => Autoplay,
                FeaturePolicyConstants.HttpFeatures.Battery => Battery,
                FeaturePolicyConstants.HttpFeatures.Camera => Camera,
                FeaturePolicyConstants.HttpFeatures.DisplayCapture => DisplayCapture,
                FeaturePolicyConstants.HttpFeatures.DocumentDomain => DocumentDomain,
                FeaturePolicyConstants.HttpFeatures.EncryptedMedia => EncryptedMedia,
                FeaturePolicyConstants.HttpFeatures.ExecutionWhileNotRendered => ExecutionWhileNotRendered,
                FeaturePolicyConstants.HttpFeatures.ExecutionWhileOutOfViewport => ExecutionWhileOutOfViewport,
                FeaturePolicyConstants.HttpFeatures.Fullscreen => Fullscreen,
                FeaturePolicyConstants.HttpFeatures.Geolocation => Geolocation,
                FeaturePolicyConstants.HttpFeatures.Gyroscope => Gyroscope,
                FeaturePolicyConstants.HttpFeatures.LayoutAnimations => LayoutAnimations,
                FeaturePolicyConstants.HttpFeatures.LegacyImageFormats => LegacyImageFormats,
                FeaturePolicyConstants.HttpFeatures.NavigationOverride => NavigationOverride,
                FeaturePolicyConstants.HttpFeatures.Magnetometer => Magnetometer,
                FeaturePolicyConstants.HttpFeatures.Microphone => Microphone,
                FeaturePolicyConstants.HttpFeatures.Midi => Midi,
                FeaturePolicyConstants.HttpFeatures.OversizedImages => OversizedImages,
                FeaturePolicyConstants.HttpFeatures.Payment => Payment,
                FeaturePolicyConstants.HttpFeatures.PictureInPicture => PictureInPicture,
                FeaturePolicyConstants.HttpFeatures.PublickeyCredentials => PublickeyCredentials,
                FeaturePolicyConstants.HttpFeatures.Speaker => Speaker,
                FeaturePolicyConstants.HttpFeatures.SyncXhr => SyncXhr,
                FeaturePolicyConstants.HttpFeatures.Usb => Usb,
                FeaturePolicyConstants.HttpFeatures.WakeLock => WakeLock,
                FeaturePolicyConstants.HttpFeatures.XrSpatialTracking => XrSpatialTracking,
                _ => Accelerometer
            };
        }
    }
}
