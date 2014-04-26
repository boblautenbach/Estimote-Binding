using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libEstimoteSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true)]
//[assembly: LinkWith ("libEstimoteSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, 
//	Frameworks = "CoreGraphics SystemConfiguration CoreBluetooth Foundation UIKit CoreLocation",  ForceLoad = true, LinkerFlags = "-ObjC")]

