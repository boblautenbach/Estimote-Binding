using System;
using System.Drawing;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreBluetooth;
using MonoTouch.CoreLocation;


namespace EstimoteBinding {

	[BaseType (typeof (NSObject))]
	public partial interface ESTBeaconUpdateInfo {

		[Export ("currentFirmwareVersion", ArgumentSemantic.Retain)]
		string CurrentFirmwareVersion { get; set; }

		[Export ("supportedHardware", ArgumentSemantic.Retain)]
		NSArray [] SupportedHardware { get; set; }
	}


	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconDelegate {

		[Export ("beaconConnectionDidFail:withError:")]
		void ConnectionDidFail (ESTBeacon beacon, NSError error);

		[Export ("beaconConnectionDidSucceeded:")]
		void  ConnectionDidSucceed (ESTBeacon beacon);

		[Export ("beaconDidDisconnect:withError:")]
		void DidDisconnect (ESTBeacon beacon, NSError error);
	}

	public delegate void ESTCompletionBlock(NSError error);
	public delegate void ESTUnsignedCompletionBlock(byte value, NSError error);
	public delegate void ESTPowerCompletionBlock(byte value, NSError error);
	public delegate void ESTUnsignedShortCompletionBlock(ushort value, NSError error);
	public delegate void ESTBoolCompletionBlock(bool value, NSError error);
	public delegate void ESTStringCompletionBlock(NSString value, NSError error);


	[BaseType (typeof (NSObject))]
	public partial interface ESTBeacon {

		[Export ("firmwareState")]
		ESTBeaconFirmwareState FirmwareState { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconDelegate Delegate { get; set; }

		[Export ("macAddress", ArgumentSemantic.Retain)]
		string MacAddress { get; set; }

		[Export ("proximityUUID", ArgumentSemantic.Retain)]
		NSUuid ProximityUUID { get; set; }

		[Export ("major", ArgumentSemantic.Retain)]
		NSNumber Major { get; set; }

		[Export ("minor", ArgumentSemantic.Retain)]
		NSNumber Minor { get; set; }

		[Export ("rssi")]
		int Rssi { get; set; }

		//No longer appears avail in 7.1
//		[Export ("ibeacon", ArgumentSemantic.Retain)]
//		CLBeacon Ibeacon { get; set; }

		[Export ("distance", ArgumentSemantic.Retain)]
		NSNumber Distance { get; set; }

		[Export ("proximity")]
		CLProximity Proximity { get; set; }

		[Export ("measuredPower", ArgumentSemantic.Retain)]
		NSNumber MeasuredPower { get; set; }

		[Export ("peripheral", ArgumentSemantic.Retain)]
		CBPeripheral Peripheral { get; set; }

		[Export ("isConnected")]
		bool IsConnected { get; }

		[Export ("power", ArgumentSemantic.Retain)]
		NSNumber Power { get; set; }

		[Export ("advInterval", ArgumentSemantic.Retain)]
		NSNumber AdvInterval { get; set; }

		[Export ("batteryLevel", ArgumentSemantic.Retain)]
		NSNumber BatteryLevel { get; set; }

		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
		string HardwareVersion { get; set; }

		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
		string FirmwareVersion { get; set; }

		[Export ("firmwareUpdateInfo")]
		ESTBeaconFirmwareUpdate FirmwareUpdateInfo { get; }

		[Export ("connectToBeacon")]
		void ConnectToBeacon ();

		[Export ("disconnectBeacon")]
		void DisconnectBeacon ();

		[Export ("readBeaconProximityUUIDWithCompletion:")]
		void ReadBeaconProximityUUIDWithCompletion (ESTStringCompletionBlock completion);

		[Export ("readBeaconMajorWithCompletion:")]
		void ReadBeaconMajorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconMinorWithCompletion:")]
		void ReadBeaconMinorWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconAdvIntervalWithCompletion:")]
		void ReadBeaconAdvIntervalWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconPowerWithCompletion:")]
		void ReadBeaconPowerWithCompletion (ESTPowerCompletionBlock completion);

		[Export ("readBeaconBatteryWithCompletion:")]
		void ReadBeaconBatteryWithCompletion (ESTUnsignedShortCompletionBlock completion);

		[Export ("readBeaconFirmwareVersionWithCompletion:")]
		void ReadBeaconFirmwareVersionWithCompletion (ESTStringCompletionBlock completion);

		[Export ("readBeaconHardwareVersionWithCompletion:")]
		void ReadBeaconHardwareVersionWithCompletion (ESTStringCompletionBlock completion);

		[Export ("writeBeaconProximityUUID:withCompletion:")]
		void WriteBeaconProximityUUID (string pUUID, ESTStringCompletionBlock completion);

		[Export ("writeBeaconMajor:withCompletion:")]
		void WriteBeaconMajor (ushort major, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconMinor:withCompletion:")]
		void WriteBeaconMinor (ushort minor, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconAdvInterval:withCompletion:")]
		void WriteBeaconAdvInterval (ushort interval, ESTUnsignedShortCompletionBlock completion);

		[Export ("writeBeaconPower:withCompletion:")]
		void WriteBeaconPower (ESTBeaconPower power, ESTPowerCompletionBlock completion);

//		[Export ("checkFirmwareUpdateWithCompletion:")]
//		void CheckFirmwareUpdateWithCompletion (ESTFirmwareUpdateCompletionBlock completion);

		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
		void UpdateBeaconFirmwareWithProgress (ESTStringCompletionBlock progress, ESTCompletionBlock completion);
	}

	[Model, BaseType (typeof (NSObject))]
	public partial interface ESTBeaconManagerDelegate {

		[Export ("beaconManager:didRangeBeacons:inRegion:")]
		void DidRangeBeacons (ESTBeaconManager manager, ESTBeacon [] beacons, ESTBeaconRegion region);

		[Export ("beaconManager:rangingBeaconsDidFailForRegion:withError:")]
		void RangingBeaconsDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		[Export ("beaconManager:monitoringDidFailForRegion:withError:")]
		void MonitoringDidFailForRegion (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);

		[Export ("beaconManager:didEnterRegion:")]
		void DidEnterRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		[Export ("beaconManager:didExitRegion:")]
		void DidExitRegion (ESTBeaconManager manager, ESTBeaconRegion region);

		[Export ("beaconManager:didDetermineState:forRegion:")]
		void DidDetermineState (ESTBeaconManager manager, CLRegionState state, ESTBeaconRegion region);

		[Export ("beaconManagerDidStartAdvertising:error:")]
		void Error (ESTBeaconManager manager, NSError error);

		[Export ("beaconManager:didDiscoverBeacons:inRegion:")]
		void DidDiscoverBeacons (ESTBeaconManager manager,  ESTBeacon [] beacons, ESTBeaconRegion region);

		[Export ("beaconManager:didFailDiscoveryInRegion:")]
		void DidFailDiscoveryInRegion (ESTBeaconManager manager, ESTBeaconRegion region);
	}

	[BaseType (typeof (CLLocationManagerDelegate))]
	public partial interface ESTBeaconManager   {

		[Export ("delegate", ArgumentSemantic.Assign)]
		ESTBeaconManagerDelegate Delegate { get; set; }

		[Export ("avoidUnknownStateBeacons")]
		bool AvoidUnknownStateBeacons { get; set; }

		[Export ("virtualBeaconRegion", ArgumentSemantic.Retain)]
		ESTBeaconRegion VirtualBeaconRegion { get; set; }

		[Export ("startRangingBeaconsInRegion:")]
		void StartRangingBeaconsInRegion (ESTBeaconRegion region);

		[Export ("startMonitoringForRegion:")]
		void StartMonitoringForRegion (ESTBeaconRegion region);

		[Export ("stopRangingBeaconsInRegion:")]
		void StopRangingBeaconsInRegion (ESTBeaconRegion region);

		[Export ("stopMonitoringForRegion:")]
		void StopMonitoringForRegion (ESTBeaconRegion region);

		[Export ("requestStateForRegion:")]
		void RequestStateForRegion (ESTBeaconRegion region);

		[Export ("startAdvertising:major:minor:identifier:")]
		void StartAdvertising (ushort major, ushort minor, string identifier);

		[Export ("stopAdvertising")]
		void StopAdvertising ();

		[Export ("startEstimoteBeaconsDiscoveryForRegion:")]
		void StartEstimoteBeaconsDiscoveryForRegion (ESTBeaconRegion region);

		[Export ("stopEstimoteBeaconDiscovery")]
		void StopEstimoteBeaconDiscovery ();
	}

	/// <summary>
	/// A ESTBeaconRegion object defines a type of region that is based on the device’s proximity to a Bluetooth beacon, 
	/// as opposed to a geographic location. A beacon region looks for devices whose identifying information matches the information you provide. 
	/// When that device comes in range, the region triggers the delivery of an appropriate notification.
	/// You can monitor beacon regions in two ways. To receive notifications when a device enters or exits 
	/// the vicinity of a beacon, use the startMonitoringForRegion: method of your location manager object. 
	/// While a beacon is in range, you can also call the startRangingBeaconsInRegion: method to begin receiving 
	/// notifications when the relative distance to the beacon changes.
	///	ESTBeaconRegion extends basic CLBeaconRegion Core Location object, allowing to directly initialize 
	/// region that is supported by Estimote Cloud platform.
	/// </summary>
	[BaseType (typeof (CLBeaconRegion))]
	public partial interface ESTBeaconRegion{

		/// <summary>
		/// Initialize an Estimote beacon region. Major and minor values will be wildcarded.
		/// </summary>
		/// <param name="identifier">Region identifier</param>
		[Export ("initWithProximityUUID:identifier:")]
		IntPtr Constructor (NSUuid uid, string identifier);

		/// <summary>
		/// Initialize an Estimote beacon region with major value. Minor value will be wildcarded.
		/// </summary>
		/// <param name="major">Major location value</param>
		/// <param name="identifier">Region identifier</param>
		[Export ("initWithProximityUUID:major:identifier:")]
		IntPtr Constructor (NSUuid uid, ushort major, string identifier);

		/// <summary>
		/// Initialize a Estimote beacon region identified by a major and minor values.
		/// </summary>
		/// <param name="major">Major location value. Represents the most significant value in a beacon.</param>
		/// <param name="minor">Minor location value. Represents the least significant value in a beacon.</param>
		/// <param name="identifier">Region identifier</param>
		[Export ("initWithProximityUUID:major:minor:identifier:")]
		IntPtr Constructor (NSUuid uid, ushort major, ushort minor, string identifier);
	
	}
}


//namespace EstimoteBinding 
//{
//
//	[BaseType (typeof (NSObject))]
//	public partial interface ESTBeaconUpdateInfo {
//
//		[Export ("currentFirmwareVersion", ArgumentSemantic.Retain)]
//		string CurrentFirmwareVersion { get; set; }
//
//		[Export ("supportedHardware", ArgumentSemantic.Retain)]
//		NSObject [] SupportedHardware { get; set; }
//	}
//
//	/// <summary>
//	/// Estimote beacon delegate protocol.
//	/// ESTBeaconDelegate defines beacon connection delegate methods. Connection is an asynchronous operation 
//	/// so you need to be prepared that eg. beaconDidDisconnectWith: method can be invoked without previous action.
//	/// </summary>
//	[Model, Protocol, BaseType (typeof (NSObject))]
//	public partial interface ESTBeaconDelegate {
//
//		/// <summary>
//		/// Delegate method that indicates error in beacon connection.
//		/// </summary>
//		/// <param name="beacon">Reference to beacon object</param>
//		/// <param name="error">Information about reason of error</param>
//		[Export ("beaconConnectionDidFail:withError:")]
//		void ConnectionDidFail (ESTBeacon beacon, NSError error);
//
//		/// <summary>
//		/// Delegate method that indicates success in beacon connection.
//		/// </summary>
//		/// <param name="beacon">Reference to beacon object</param>
//		[Export ("beaconConnectionDidSucceeded:")]
//		void ConnectionDidSucceed(ESTBeacon beacon);
//
//		/// <summary>
//		/// Delegate method that beacon did disconnect with device.
//		/// </summary>
//		/// <param name="beacon">Reference to beacon object</param>
//		/// <param name="error">Information about reason of error</param>
//		[Export ("beaconDidDisconnect:withError:")]
//		void DidDisconnect (ESTBeacon beacon, NSError error);
//	}
//
//	public delegate void ESTCompletionBlock(NSError error);
//	public delegate void ESTUnsignedCompletionBlock(byte value, NSError error);
//	public delegate void ESTUnsignedShortCompletionBlock(ushort value, NSError error);
//	public delegate void ESTBoolCompletionBlock(bool value, NSError error);
//	public delegate void ESTStringCompletionBlock(NSString value, NSError error);
//
//	[BaseType (typeof (NSObject))]
//	public partial interface ESTBeacon {
//
//		[Export ("firmwareState")]
//		ESTBeaconFirmwareState FirmwareState { get; set; }
//
//		[Export ("delegate", ArgumentSemantic.Assign)]
//		ESTBeaconDelegate Delegate { get; set; }
//
//		///////////////////////////////////////////////////////
//		// Bluetooth beacon available when used with startEstimoteBeaconsDiscoveryForRegion:
//		[Export ("peripheral", ArgumentSemantic.Retain)]
//		CBPeripheral Peripheral { get; set; }
//
//		[Export ("macAddress", ArgumentSemantic.Retain)]
//		string MacAddress { get; set; }
//
//		[Export ("proximityUUID", ArgumentSemantic.Retain)]
//		NSObject ProximityUUID { get; set; }
//
//		[Export ("major", ArgumentSemantic.Retain)]
//		NSNumber Major { get; set; }
//
//		[Export ("minor", ArgumentSemantic.Retain)]
//		NSNumber Minor { get; set; }
//
//		[Export ("rssi")]
//		int Rssi { get; set; }
//
//		[Export ("distance", ArgumentSemantic.Retain)]
//		NSNumber Distance { get; set; }
//
//		[Export ("proximity")]
//		CLProximity Proximity { get; set; }
//
//		[Export ("measuredPower", ArgumentSemantic.Retain)]
//		NSNumber MeasuredPower { get; set; }
//
//		[Export ("frequency", ArgumentSemantic.Retain)]
//		NSNumber Frequency { get; set; }
//
//		[Export ("isConnected")]
//		bool IsConnected { get; }
//
//		[Export ("power", ArgumentSemantic.Retain)]
//		NSNumber Power { get; set; }
//
//		[Export ("advInterval", ArgumentSemantic.Retain)]
//		NSNumber AdvInterval { get; set; }
//
//		[Export ("batteryLevel", ArgumentSemantic.Retain)]
//		NSNumber BatteryLevel { get; set; }
//
//		[Export ("hardwareVersion", ArgumentSemantic.Retain)]
//		string HardwareVersion { get; set; }
//
//		[Export ("firmwareVersion", ArgumentSemantic.Retain)]
//		string FirmwareVersion { get; set; }
//
//		//		[Export ("firmwareUpdateInfo")]
//		//		ESTBeaconFirmwareUpdate FirmwareUpdateInfo { get; }
//		//
//		[Export ("connectToBeacon")]
//		void ConnectToBeacon ();
//
//		/////////////////////////////////////////////////////
//		// Core location properties
//		[Export ("ibeacon", ArgumentSemantic.Retain)]
//		CLBeacon Ibeacon { get; set; }
//
//		[Export ("disconnectBeacon")]
//		void DisconnectBeacon ();
//
//		[Export ("readBeaconProximityUUIDWithCompletion:")]
//		void ReadBeaconProximityUUID (ESTStringCompletionBlock completion);
//
//		[Export ("readBeaconMajorWithCompletion:")]
//		void ReadBeaconMajor(ESTUnsignedShortCompletionBlock completion);
//
//		[Export ("readBeaconMinorWithCompletion:")]
//		void ReadBeaconMinor(ESTUnsignedShortCompletionBlock completion);
//
//		[Export ("readBeaconAdvIntervalWithCompletion:")]
//		void ReadBeaconAdvInterval(ESTUnsignedShortCompletionBlock completion);
//
//		//		[Export ("readBeaconPowerWithCompletion:")]
//		//		void ReadBeaconPower (ESTPowerCompletionBlock completion);
//		//
//		[Export ("readBeaconBatteryWithCompletion:")]
//		void ReadBeaconBattery (ESTUnsignedShortCompletionBlock completion);
//
//		[Export ("readBeaconFirmwareVersionWithCompletion:")]
//		void ReadBeaconFirmwareVersion (ESTStringCompletionBlock completion);
//
//		[Export ("readBeaconHardwareVersionWithCompletion:")]
//		void ReadBeaconHardwareVersion (ESTStringCompletionBlock completion);
//
//		[Export ("writeBeaconProximityUUID:withCompletion:")]
//		void WriteBeaconProximityUUID (string pUUID, ESTStringCompletionBlock completion);
//
//		[Export ("writeBeaconMajor:withCompletion:")]
//		void WriteBeaconMajor (ushort major, ESTUnsignedShortCompletionBlock completion);
//
//		[Export ("writeBeaconMinor:withCompletion:")]
//		void WriteBeaconMinor (ushort minor, ESTUnsignedShortCompletionBlock completion);
//
//		[Export ("writeBeaconAdvInterval:withCompletion:")]
//		void WriteBeaconAdvInterval (ushort interval, ESTUnsignedShortCompletionBlock completion);
//
//		[Export ("writeBeaconPower:withCompletion:")]
//		void WriteBeaconPower (ESTBeaconPower power, ESTUnsignedCompletionBlock completion);
//
//		//		[Export ("checkFirmwareUpdateWithCompletion:")]
//		//		void CheckFirmwareUpdateWithCompletion (ESTFirmwareUpdateCompletionBlock completion);
//		//
//		[Export ("updateBeaconFirmwareWithProgress:andCompletion:")]
//		void UpdateBeaconFirmwareWithProgress (ESTStringCompletionBlock progress, ESTCompletionBlock completion);
//	}
//
//	[Model, Protocol, BaseType (typeof (NSObject))]
//	public partial interface ESTBeaconManagerDelegate {
//
//		[Export ("beaconManager:didRangeBeacons:inRegion:")]
//		void DidRangeBeacons (ESTBeaconManager manager, NSArray [] beacons, ESTBeaconRegion region);
//
//		[Export ("beaconManager:rangingBeaconsDidFailForRegion:withError:")]
//		void RangingBeaconsDidFail (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);
//
//		[Export ("beaconManager:monitoringDidFailForRegion:withError:")]
//		void MonitoringDidFail (ESTBeaconManager manager, ESTBeaconRegion region, NSError error);
//
//		[Export ("beaconManager:didEnterRegion:")]
//		void DidEnterRegion (ESTBeaconManager manager, ESTBeaconRegion region);
//
//		[Export ("beaconManager:didExitRegion:")]
//		void DidExitRegion (ESTBeaconManager manager, ESTBeaconRegion region);
//
//		[Export ("beaconManager:didDetermineState:forRegion:")]
//		void DidDetermineState (ESTBeaconManager manager, CLRegionState state, ESTBeaconRegion region);
//
//		[Export ("beaconManagerDidStartAdvertising:error:")]
//		void Error (ESTBeaconManager manager, NSError error);
//
//		[Export ("beaconManager:didDiscoverBeacons:inRegion:")]
//		void DidDiscoverBeacons (ESTBeaconManager manager, NSArray [] beacons, ESTBeaconRegion region);
//
//		[Export ("beaconManager:didFailDiscoveryInRegion:")]
//		void DidFailDiscovery (ESTBeaconManager manager, ESTBeaconRegion region);
//	}
//
//	[BaseType (typeof (CLLocationManagerDelegate))]
//	public partial interface ESTBeaconManager {
//
//		[Export ("delegate", ArgumentSemantic.Assign)]
//		ESTBeaconManagerDelegate Delegate { get; set; }
//
//		[Export ("avoidUnknownStateBeacons")]
//		bool AvoidUnknownStateBeacons { get; set; }
//
//		[Export ("virtualBeaconRegion", ArgumentSemantic.Retain)]
//		ESTBeaconRegion VirtualBeaconRegion { get; set; }
//
//		[Export ("startRangingBeaconsInRegion:")]
//		void StartRangingBeacons (ESTBeaconRegion region);
//
//		[Export ("startMonitoringForRegion:")]
//		void StartMonitoring (ESTBeaconRegion region);
//
//		[Export ("stopRangingBeaconsInRegion:")]
//		void StopRangingBeacons (ESTBeaconRegion region);
//
//		[Export ("stopMonitoringForRegion:")]
//		void StopMonitoring (ESTBeaconRegion region);
//
//		[Export ("requestStateForRegion:")]
//		void RequestState (ESTBeaconRegion region);
//
//		[Export ("startAdvertising:major:minor:identifier:")]
//		void StartAdvertising (ushort major, ushort minor, string identifier);
//
//		[Export ("stopAdvertising")]
//		void StopAdvertising ();
//
//		[Export ("startEstimoteBeaconsDiscoveryForRegion:")]
//		void StartEstimoteBeaconsDiscovery (ESTBeaconRegion region);
//
//		[Export ("stopEstimoteBeaconDiscovery")]
//		void StopEstimoteBeaconDiscovery ();
//	}
//
//	/// <summary>
//	/// A ESTBeaconRegion object defines a type of region that is based on the device’s proximity to a Bluetooth beacon, 
//	/// as opposed to a geographic location. A beacon region looks for devices whose identifying information matches the information you provide. 
//	/// When that device comes in range, the region triggers the delivery of an appropriate notification.
//	/// You can monitor beacon regions in two ways. To receive notifications when a device enters or exits 
//	/// the vicinity of a beacon, use the startMonitoringForRegion: method of your location manager object. 
//	/// While a beacon is in range, you can also call the startRangingBeaconsInRegion: method to begin receiving 
//	/// notifications when the relative distance to the beacon changes.
//	///	ESTBeaconRegion extends basic CLBeaconRegion Core Location object, allowing to directly initialize 
//	/// region that is supported by Estimote Cloud platform.
//	/// </summary>
//	[BaseType (typeof (CLBeaconRegion))]
//	public partial interface ESTBeaconRegion {
//
//		/// <summary>
//		/// Initialize an Estimote beacon region. Major and minor values will be wildcarded.
//		/// </summary>
//		/// <param name="identifier">Region identifier</param>
//		[Export ("initRegionWithIdentifier:")]
//		IntPtr Constructor (string identifier);
//
//		/// <summary>
//		/// Initialize an Estimote beacon region with major value. Minor value will be wildcarded.
//		/// </summary>
//		/// <param name="major">Major location value</param>
//		/// <param name="identifier">Region identifier</param>
//		[Export ("initRegionWithMajor:identifier:")]
//		IntPtr Constructor (ushort major, string identifier);
//
//		/// <summary>
//		/// Initialize a Estimote beacon region identified by a major and minor values.
//		/// </summary>
//		/// <param name="major">Major location value. Represents the most significant value in a beacon.</param>
//		/// <param name="minor">Minor location value. Represents the least significant value in a beacon.</param>
//		/// <param name="identifier">Region identifier</param>
//		[Export ("initRegionWithMajor:minor:identifier:")]
//		IntPtr Constructor (ushort major, ushort minor, string identifier);
//	}
//
//}
