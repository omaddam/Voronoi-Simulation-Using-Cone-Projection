using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoronoiDiagram.DataStructure;

namespace VoronoiDiagram
{
    public class DiagramManager : MonoBehaviour
    {

        #region Initialization

        /// <summary>
        /// Executes once on start.
        /// </summary>
        private void Awake()
        {
            Collider = Bounds.GetComponent<Collider2D>();
        }

        /// <summary>
        /// Initializes the diagram.
        /// </summary>
        /// <param name="dimensions">The width and length of the diagram.</param>
        /// <param name="seeds">The center of each region to be created.</param>
        public void Initialize(Vector2 dimensions, List<Seed> seeds)
        {
            // Set the boundaries of the diagram
            InitializeBounds(dimensions);

            // Create regions
            InitializeRegions(seeds);
        }

        #endregion

        #region Fields/Properties

        [Header("Bounds")]

        /// <summary>
        /// References the gameobject that represents the bounds of the diagram.
        /// </summary>
        [SerializeField]
        private GameObject Bounds;

        /// <summary>
        /// References the collider of the diagram that will be used to determine its bounds.
        /// </summary>
        private Collider2D Collider;



        [Header("Regions")]

        /// <summary>
        /// References the gameobject that will hold all generated regions.
        /// </summary>
        [SerializeField]
        private GameObject RegionsParent;


        /// <summary>
        /// References the template prefab used when initializing the regions.
        /// </summary>
        [SerializeField]
        private GameObject RegionTemplate;

        /// <summary>
        /// List of all regions created in this diagram.
        /// </summary>
        private List<DiagramRegion> Regions;

        #endregion

        #region Methods

        /// <summary>
        /// Sets the boundaries of the diagram.
        /// </summary>
        private void InitializeBounds(Vector2 dimensions)
        {
            // Create square mesh
            Mesh square = new Mesh();
            square.vertices = new Vector3[]
            {
                new Vector3(0.5f, 0.5f, 0),
                new Vector3(-0.5f, 0.5f, 0),
                new Vector3(-0.5f, -0.5f, 0),
                new Vector3(0.5f, -0.5f, 0)
            };
            square.uv = new Vector2[4]
            {
                new Vector2(0.5f, 0.5f),
                new Vector2(-0.5f, -0.5f),
                new Vector2(0.5f, -0.5f),
                new Vector2(-0.5f, 0.5f)
            };
            square.triangles = new int[] { 0, 3, 2, 2, 1, 0 };
            Bounds.GetComponent<MeshFilter>().mesh = square;

            // Set the scale
            Bounds.transform.localScale = new Vector3(dimensions.x, dimensions.y, 1);
        }

        /// <summary>
        /// Creates a single region for each provided seed.
        /// </summary>
        private void InitializeRegions(List<Seed> seeds)
        {
            // Delete all current regions
            foreach (Transform region in RegionsParent.transform)
                GameObject.Destroy(region.gameObject);
            Regions = new List<DiagramRegion>();

            // Create new regions
            foreach(var seed in seeds)
            {
                // Create a new region instance
                GameObject region = Instantiate(RegionTemplate, RegionsParent.transform);

                // Extract the script
                DiagramRegion script = region.GetComponent<DiagramRegion>();

                // Initialize data
                script.Initialize(seed);

                // Add to list
                Regions.Add(script);
            }
        }

        #endregion

    }
}