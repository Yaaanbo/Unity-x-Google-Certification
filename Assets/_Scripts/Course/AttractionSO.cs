using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attraction Config", menuName = "Config/Attraction Config New")]
public class AttractionSO : ScriptableObject
{
    [Header("Attraction Information")]
    public string id;
    public string title;
    public string author;
    [TextArea] public string description;
    public string location;
    public int starRating;

    [Header("Attraction Display")]
    public Sprite image;

    [Header("UI Positioning")]
    public Vector2 thumbnailSize;
    public Vector3 thumbnailPosition;

    public Vector2 headerImageSize;
    public Vector3 headerImagePosition;
}
