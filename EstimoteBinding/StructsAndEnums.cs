﻿using System;

namespace EstimoteBinding
{

	public enum ESTBeaconPower 
	{
		Level1 = -30,
		Level2 = -20,
		Level3 = -16,
		Level4 = -12,
		Level5 = -8,
		Level6 = -4,
		Level7 = 0,
		Level8 = 4
	}

	public enum ESTBeaconFirmwareState
	{
		Boot,
		App
	}

	public enum ESTBeaconFirmwareUpdate  {
		None,
		Available,
		NotAvailable
	}
}

