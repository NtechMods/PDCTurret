using System.Collections.Generic;
using static WeaponThread.WeaponStructure;
using static WeaponThread.WeaponStructure.WeaponDefinition;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.PartAnimationSetDef.EventTriggers;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove.MoveType;
using static WeaponThread.WeaponStructure.WeaponDefinition.AnimationDef.RelMove;
namespace WeaponThread
{ // Don't edit above this line
    partial class Weapons
    {
        private AnimationDef TopRetractPDCAnims => new AnimationDef
        {
			
			
			Emissives = new []
            {
				
				Emissive(
                    EmissiveName: "TurnOnOff",
                    Colors: new []
                    {
                        Color(red:0.1f, green: 0.8f, blue:0.1f, alpha: 1),//will transitions from one color to the next if more than one
                        Color(red:0.2f, green: 0.8f, blue:0.2f, alpha: 1),
                    }, 
                    IntensityFrom:0, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:1, 
                    CycleEmissiveParts: true,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive",
                    }),
				
				
				
                Emissive(
                    EmissiveName: "FiringEmissive",
                    Colors: new []
                    {
                        Color(red:0.4f, green: 0.4f, blue:0.0f, alpha: 1),//will transitions form one color to the next if more than one
                    }, 
                    IntensityFrom:0, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:1, 
                    CycleEmissiveParts: true,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: true,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive",
                        
                    }),	

                Emissive(
                    EmissiveName: "StopFiringEmissive",
                    Colors: new []
                    {
                        
                        Color(red:0.4f, green: 0.4f, blue:1.6f, alpha: 4),
                        Color(red:0.3f, green: 0.3f, blue:1.4f, alpha: 3),
                        Color(red:0.2f, green: 0.2f, blue:1.2f, alpha: 2),
                        Color(red:0.1f, green: 0.1f, blue:1.0f, alpha: 1),
                        Color(red:0.09f, green: 0.09f, blue:0.8f, alpha: 0.8f),
                        Color(red:0.08f, green: 0.08f, blue:0.6f, alpha: 0.6f),
                        Color(red:0.07f, green: 0.07f, blue:0.4f, alpha: 0.4f),
                        Color(red:0.06f, green: 0.06f, blue:0.2f, alpha: 0.2f),
                        Color(red:0.05f, green: 0.05f, blue:0.1f, alpha: 0.1f),
                        Color(red:0.02f, green: 0.02f, blue:0.08f, alpha: 0.05f),
                        Color(red:0, green: 0, blue:0, alpha: 0),//will transitions form one color to the next if more than one
                    }, 
                    IntensityFrom:1, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:0, 
                    CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: false,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive",
                        
                    }),
                Emissive(
                    EmissiveName: "Overheated",
                    Colors: new []
                    {
                        Color(red:25, green: 2, blue:2, alpha: 1),//will transitions form one color to the next if more than one
                    }, 
                    IntensityFrom:.1f, //starting intensity, can be 0.0-1.0 or 1.0-0.0, setting both from and to, to the same value will stay at that value
                    IntensityTo:5f, 
                    CycleEmissiveParts: false,//whether to cycle from one part to the next, while also following the Intensity Range, or set all parts at the same time to the same value
                    LeavePreviousOn: false,//true will leave last part at the last setting until end of animation, used with cycleEmissiveParts
                    EmissivePartNames: new []
                    {
                        "Emissive",
                        
                    }),			
            },
			
			
			
			
			
            WeaponAnimationSets = new[]
            {
                #region Parts Animations
                new PartAnimationSetDef()
                {
                    SubpartId = Names("PDCEle"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(-80, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(-10, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(80, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(10, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("barrels"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, -1.0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 150), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, -0.2f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 30), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 60, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 1.0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -150), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0.2f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -30), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },



                new PartAnimationSetDef()
                {
                    SubpartId = Names("MagazineLeft"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff, Reloading),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 80, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("MagazineRight"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff, Reloading),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 80, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },
				#endregion

                #region Reloading
                
                new PartAnimationSetDef()
                {
                    SubpartId = Names("MagazineRight"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff, Reloading),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 140, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
												
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("MagazineLeft"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff, Reloading),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[Reloading] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 140, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -25), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 50, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(-0.001f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, -5), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
												
                    }
                },              	
                #endregion

                #region Deploy
                new PartAnimationSetDef()
                {
                    SubpartId = Names("RailB"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -1.4f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 1.4f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("RailA"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -2.9f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {
                                
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 2.9f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("PDCAzi"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "Emissive",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 2.9f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -2.9f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },						
                    }
                },


                new PartAnimationSetDef()
                {
                    SubpartId = Names("PDCDoorB"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "Emissive",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0.001f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(85, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -0.074f, -0.07f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0.074f, 0.07f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -0.001f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(-85, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                
								
                            },						
                    }
                },
                new PartAnimationSetDef()
                {
                    SubpartId = Names("PDCDoorF"),
                    BarrelId = "Any", //only used for firing, use "Any" for all muzzles
                    StartupFireDelay = 0,
                    AnimationDelays = Delays(FiringDelay : 0, ReloadingDelay: 0, OverheatedDelay: 0, TrackingDelay: 0, LockedDelay: 0, OnDelay: 0, OffDelay: 0, BurstReloadDelay: 0, OutOfAmmoDelay: 0, PreFireDelay: 0, StopFiringDelay: 0),//Delay before animation starts
                    Reverse = Events(Firing, StopFiring), // (Firing, Overheated)
                    Loop = Events(Firing), // (Firing, Overheated)
                    TriggerOnce = Events(PreFire, StopFiring, Firing, TurnOn, TurnOff),
                    ResetEmissives = Events(StopTracking, TurnOff),
                    EventMoveSets = new Dictionary<PartAnimationSetDef.EventTriggers, RelMove[]>
                    {
                        
                        
						[TurnOn] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire. define a new[] for each
                            {
								
                                
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 20, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "Emissive",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0.001f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(-85, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 10, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -0.074f, 0.07f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                            },
						[TurnOff] =
                            new[] //Firing, Reloading, Overheated, Tracking, On, Off, BurstReload, OutOfAmmo, PreFire define a new[] for each
                            {

                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Delay, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 30, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, 0.074f, -0.07f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(0, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
								new RelMove
                                {
                                    CenterEmpty = "",//Specifiy an empty on the subpart to rotate around
                                    TicksToMove = 90, //number of ticks to complete motion, 60 = 1 second

                                    MovementType = Linear, // ExpoGrowth (speedsup),  ExpoDecay (slows down), Linear, Delay, Show, Hide
                                    EmissiveName = "",//name of defined emissive 
                                    LinearPoints = new[]
                                    {
                                        Transformation(0f, -0.001f, 0f), //linear movement x=L,R y=U,D z=F,B
                                    },
                                    Rotation = Transformation(85, 0, 0), //degrees
                                    RotAroundCenter = Transformation(0, 0, 0), //degrees, rotates around CenterEmpty
                                },
                                
								
                            },						
                    }
                },
                #endregion

            }
            
        };
    }
}
