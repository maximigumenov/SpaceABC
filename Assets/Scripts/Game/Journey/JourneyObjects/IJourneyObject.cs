using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IJourneyObject 
{
    List<string> types { get; set; }
    Transform cameraPosition { get; }
    Transform cameraView { get; }
}
