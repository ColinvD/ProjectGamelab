using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Kinect = Windows.Kinect;
using Joint = Windows.Kinect.Joint;

public class BodySourceView : MonoBehaviour 
{
    public BodySourceManager mBodySourceManager;
    public GameObject mJointObject;

    public GameObject playerOne;
    public GameObject playerTwo;

    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    private List<Kinect.JointType> _joints = new List<Kinect.JointType>
    {
        Kinect.JointType.HandRight
    };
    
    
    
    void Update () 
    {
       
        Kinect.Body[] data = mBodySourceManager.GetData();
        if (data == null)
        {
            return;
        }
        List<ulong> trackedIds = new List<ulong>();
        foreach(var body in data)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
            }
        }

        List<ulong> knownIds = new List<ulong>(mBodies.Keys);
        foreach(ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(mBodies[trackingId]);

                mBodies.Remove(trackingId);
            }
        }

        foreach (var Body in data)
        {
            if (Body == null)
            {
                continue;
            }
            if (Body.IsTracked)
            {
                if (!mBodies.ContainsKey(Body.TrackingId))
                {
                    mBodies[Body.TrackingId] = CreateBodyObject(Body.TrackingId);
                }

                UpdateBodyObject(Body, mBodies[Body.TrackingId]);
            }
        }
        
    }

    private GameObject CreateBodyObject(ulong id)
    {
        GameObject body = new GameObject("Body: " + id);

        foreach (Kinect.JointType joint in _joints)
        {
            GameObject newJoint = Instantiate(mJointObject);
            newJoint.name = joint.ToString();

            newJoint.transform.parent = body.transform;
        }

        return body;
    }
    
    private void UpdateBodyObject(Kinect.Body body, GameObject bodyObject)
    {
        foreach(Kinect.JointType _joint in _joints)
        {
            Joint sourceJoint = body.Joints[_joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);
            targetPosition.z = 0;

            Transform jointObject = bodyObject.transform.Find(_joint.ToString());
            jointObject.position = targetPosition;
        }
       
    }
    
    private static Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * 10);
    }
}
