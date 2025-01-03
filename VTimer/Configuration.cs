﻿using Dalamud.Configuration;
using Dalamud.Plugin;
using System;
using System.Collections.Generic;
using VTimer.Consts;
using VTimer.Helpers;

namespace VTimer
{
    [Serializable]
    public class PluginConfiguration : IPluginConfiguration
    {
        // this version that I have no intent of using is required for extending IPluginConfiguration
        public int Version { get; set; } = 0;


        // Anything that will be saved to the config file must be public, not internal.
        public Val<int> EurekaForewarning = new(180);
        public Val<int> FarmForewarning = new(180);

        public Val<int> RealForewarning = new(60*15);
        // In Eorzean Hours
        public Val<int> FarmMinDuration = new(24);

        public Dictionary<string, bool> TrackerState = new Dictionary<string, bool> {
            {Names.Pazuzu, false},
            {Names.Crab, false},
            {Names.Cassie, false},
            {Names.Luigi, false},
            {Names.Skoll, false},
            {Names.Penny, false},

            {Names.ColdBox, false},
            {Names.HeatBox, false},
            {Names.Preparation, false},
            {Names.Care, false},
            {Names.Support, false},
            {Names.History, false},
            {Names.Artistry, false},

            {Names.Verminion, false},
            {Names.Boat, false},
            {Names.OpenTournament, false},
            {Names.BiweeklyTournament, false},
            {Names.FashionReport, false},
        };


        // the below exist just to make saving less cumbersome
        [NonSerialized]
        private IDalamudPluginInterface? PluginInterface;

        public void Initialize(IDalamudPluginInterface pluginInterface)
        {
            this.PluginInterface = pluginInterface;
        }

        public void Save()
        {
            this.PluginInterface!.SavePluginConfig(this);
        }
    }
}
