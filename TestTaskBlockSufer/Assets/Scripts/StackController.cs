using UnityEngine;

public class StackController : MonoBehaviour
{
    public SceneReloader sceneReloader;
    public GameObject blockPrefab;
    public BoxCollider boxCollider;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collect Block")
        {
            AddBlock();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Obstacle Block")
        {
            RemoveBlock(1);
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (collision.gameObject.tag == "Finish Block")
        {
            sceneReloader.ReloadScene();
        }
    }

    public void AddBlock()
    {
        Vector3 lastChildPos = transform.GetChild(transform.childCount - 1).transform.position;
        Vector3 spawnPos = new Vector3(lastChildPos.x, lastChildPos.y - 1, lastChildPos.z);

        Instantiate(blockPrefab, spawnPos, Quaternion.identity, transform);

        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);

        boxCollider.size = new Vector3(boxCollider.size.x,boxCollider.size.y + 1,boxCollider.size.z);
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y - 0.5f);
    }

    public void RemoveBlock(int blocksCount)
    {
        if (transform.childCount > blocksCount)
        {
            for (int i = 0; i < blocksCount; i++)
            {
                boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y - 1, boxCollider.size.z);
                boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y + 0.5f);
                transform.GetChild(transform.childCount - 1).parent = null;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
            }
        }
        else sceneReloader.ReloadScene();
    }
}
