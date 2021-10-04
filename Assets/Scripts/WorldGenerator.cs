using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.U2D;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField]
    private SpriteShapeController spriteShapeController;

    [SerializeField]
    private Transform player;
    [SerializeField]
    private float generationBorder;

    [SerializeField]
    private Vector2 pointOffset;
    [SerializeField]
    private Vector2 tangentOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x >= generationBorder)
        {
            generationBorder += pointOffset.x * 3;

            for(int i =0; i < 3; i++)
            {
                Testing();
            }
        }    
    }

    [ContextMenu("Test")]
    public void Testing()
    {
        Spline spline = spriteShapeController.spline;

        Vector3 lastPoint = spline.GetPosition(spline.GetPointCount()-1);
        spline.SetPosition(spline.GetPointCount() - 1, new Vector3(lastPoint.x + pointOffset.x, lastPoint.y));

        Vector3 previousPoint = spline.GetPosition(spline.GetPointCount() - 2);
        Vector3 currentPoint = new Vector3(previousPoint.x + pointOffset.x, previousPoint.y + Random.Range(-pointOffset.y, pointOffset.y));
        Vector3 nextPoint = spline.GetPosition(spline.GetPointCount() - 1);

        spline.InsertPointAt(spline.GetPointCount() - 1,currentPoint);

        spline.SetTangentMode(spline.GetPointCount()- 2, ShapeTangentMode.Continuous);

        //Smoother curves
        spline.SetLeftTangent(spline.GetPointCount() - 2, new Vector3(-tangentOffset.x, tangentOffset.y));
        spline.SetRightTangent(spline.GetPointCount() - 2, new Vector3(tangentOffset.x, tangentOffset.y));


        //Linear curves
        //spline.SetRightTangent(spline.GetPointCount() - 2, new Vector3(((nextPoint.x - currentPoint.x) / 2), ((nextPoint.y - currentPoint.y) / 2)));
        //spline.SetLeftTangent(spline.GetPointCount() - 2, new Vector3(-((currentPoint.x - previousPoint.x) / 2), -((currentPoint.y - previousPoint.y) / 2)));

        //spline.SetRightTangent(spline.GetPointCount() - 3, new Vector3(((currentPoint.x - previousPoint.x) / 2), ((currentPoint.y - previousPoint.y) / 2)));

        //Try getting the difference betwen the last and next point and getting the average of that for the tangents.
    }

    [ContextMenu("Read Spline")]
    public void ReadSpline()
    {
        for (int i = 0; i < spriteShapeController.spline.GetPointCount(); i++)
        {
            Debug.Log($"{i} - {spriteShapeController.spline.GetPosition(i)} | {spriteShapeController.spline.GetTangentMode(i)} | {spriteShapeController.spline.GetLeftTangent(i)} | {spriteShapeController.spline.GetRightTangent(i)}");
        }
    }

    [ContextMenu("Reset Spline")]
    public void ResetSpline()
    {
        Spline spline = spriteShapeController.spline;

        spline.SetPosition(0, new Vector3(0, -.25f));
        spline.SetPosition(1, new Vector3(1, -.25f));
        spline.SetPosition(2, new Vector3(2, -.25f));

         spline.SetTangentMode(0, ShapeTangentMode.Broken);
         spline.SetLeftTangent(0, new Vector3(-0.5f, 0));
         spline.SetRightTangent(0, new Vector3(0.5f, 0));

         spline.SetTangentMode(1, ShapeTangentMode.Continuous);
         spline.SetLeftTangent(1, new Vector3(-0.5f, 0));
         spline.SetRightTangent(1, new Vector3(0.5f, 0));

         spline.SetTangentMode(2, ShapeTangentMode.Continuous);
         spline.SetLeftTangent(2, new Vector3(-0.5f, 0));
         spline.SetRightTangent(2, new Vector3(0.5f, 0));

        for (int i = spline.GetPointCount()-1; i > 2; i--)
        {
            spline.RemovePointAt(i);
        }
    }
}
