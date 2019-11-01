using System;
using System.Collections.Generic;
using System.Text;

public interface ICommando : ISpecialisedSoldier
{
    List<Mission> Missions  { get; }

    void AddMission(Mission mission);

    void CompleteMission();
}

