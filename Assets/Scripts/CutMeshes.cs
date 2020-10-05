using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Rigidbody))]

public class CutMeshes : MonoBehaviour
{
    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    private float cubesPivotDistance;
    private Vector3 cubesPivot;

    public float explosionForce = 50f;
    public float explosionRadius = 4f;
    public float explosionUpward = 0.4f;
    private Mesh mesh;
    private Material mat;
    float rbMass;
    // Use this for initialization
    private void Awake()
    {
        rbMass = GetComponent<Rigidbody>().mass;
        mesh = GetComponent<MeshFilter>().sharedMesh;
        mat = GetComponent<MeshRenderer>().sharedMaterial;
        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Bullet>())
        {
            Explode();
        }
    }
    public void Explode()
    {
        //make object disappear
        Destroy(gameObject);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    CreatePiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    private void CreatePiece(int x, int y, int z)
    {

        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<MeshRenderer>().sharedMaterial = mat;
        piece.GetComponent<MeshFilter>().sharedMesh = mesh;
        piece.AddComponent<SphereCollider>();
        //set piece position and scale
        piece.transform.position = transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = rbMass * cubeSize;
        Destroy(piece, 2f);
    }
}
