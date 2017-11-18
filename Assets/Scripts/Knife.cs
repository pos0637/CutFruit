using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public LineRenderer LineRenderer;

    public AudioSource Swing;

    private Vector3 mCurrentMousePos;

    private Vector3 mLastMousePos;

    private bool mIsMouseDown = false;

    private bool mNeedResetMousePosition = true;

    private List<Vector3> mPositions = new List<Vector3>();

    private Vector3[] mPositionArray = new Vector3[9];

    // Use this for initialization
    void Start()
    {
        LineRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ResetPosition();
            mIsMouseDown = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            mIsMouseDown = false;
            ClearPositions();
        }

        OnDrawLine();
        OnRaycast();
    }

    private void OnDrawLine()
    {
        if (!mIsMouseDown)
            return;

        mCurrentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector3.Distance(mCurrentMousePos, mLastMousePos) > 0.01f) {
            AddPosition(mLastMousePos);
            mLastMousePos = mCurrentMousePos;
        }
    }

    private void OnRaycast()
    {
        if (!mIsMouseDown)
            return;

        foreach (Vector3 position in mPositions) {
            Vector3 pos = Camera.main.WorldToScreenPoint(position);
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit[] hits = Physics.RaycastAll(ray);

            if (hits.Length > 0) {
                foreach (RaycastHit hit in hits) {
                    Debug.Log(hit.collider.gameObject.name);
                    Fruit fruit = hit.collider.gameObject.GetComponent<Fruit>();
                    if (fruit == null)
                        Debug.Log("error: " + hit.collider.gameObject.name);
                    fruit.OnCut();
                }
            }
        }
    }

    private void AddPosition(Vector3 position)
    {
        position.z = -1;
        mPositions.Add(position);
        if (mPositions.Count == 10)
            mPositions.RemoveAt(0);

        for (int i = 0; i < mPositions.Count; ++i) {
            mPositionArray[i] = mPositions[i];
        }

        for (int i = mPositions.Count; i < 9; ++i) {
            mPositionArray[i] = position;
        }

        LineRenderer.SetPositions(mPositionArray);
        LineRenderer.enabled = true;
    }

    private void ResetPosition()
    {
        if (!mNeedResetMousePosition)
            return;

        mCurrentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mLastMousePos = mCurrentMousePos;
        Swing.Play();

        mNeedResetMousePosition = false;
    }

    private void ClearPositions()
    {
        mPositions.Clear();
        LineRenderer.enabled = false;
        Swing.Stop();

        mNeedResetMousePosition = true;
    }
}
