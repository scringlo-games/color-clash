using System.Collections.Generic;
using System.Linq;
using ScringloGames.ColorClash.Runtime.Shared;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace ScringloGames.ColorClash.Runtime.PaintCoverage
{
    public class PaintCoverageTracker : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField]
        private float decalSizeContribution = 1f;
        [SerializeField]
        private Tilemap floorTilemap;
        [SerializeField]
        private GameObjectRegistrar decalRegistrar;
        private Dictionary<Vector3Int, bool> coveredTiles;

        public float Coverage { get; private set; }

        private void Awake()
        {
            this.coveredTiles = new Dictionary<Vector3Int, bool>();
            
            var bounds = this.floorTilemap.cellBounds;
            
            for (var x = bounds.xMin; x < bounds.xMax; x++)
            {
                for (var y = bounds.yMin; y < bounds.yMax; y++)
                {
                    var localPosition = new Vector3Int(x, y, 0);

                    this.coveredTiles[localPosition] = false;
                }
            }
        }

        private void OnEnable()
        {
            this.decalRegistrar.Registered += this.OnDecalRegistered;
        }

        private void OnDisable()
        {
            this.decalRegistrar.Registered -= this.OnDecalRegistered;
        }

        private float CalculateDecalCoverageArea()
        {
            foreach (var decal in this.decalRegistrar.Entities)
            {
                var spriteRenderer = decal.GetComponentInChildren<SpriteRenderer>();

                if (spriteRenderer == null)
                {
                    continue;
                }
                
                var decalWorldPosition = decal.transform.position;
                var decalExtents = spriteRenderer.bounds.extents;
                var tilemapCellBounds = this.floorTilemap.cellBounds;
                
                // Loop through all positions within the bounds of the tilemap
                for (var x = tilemapCellBounds.xMin; x < tilemapCellBounds.xMax; x++)
                {
                    for (var y = tilemapCellBounds.yMin; y < tilemapCellBounds.yMax; y++)
                    {
                        var localPosition = new Vector3Int(x, y, 0);
                        var tile = this.floorTilemap.GetTile(localPosition);

                        if (tile != null)
                        {
                            var tileWorldPosition = this.floorTilemap.CellToWorld(localPosition);
                            var distanceBetweenTileAndDecal = Vector3.Distance(tileWorldPosition, decalWorldPosition);
                            
                            if (distanceBetweenTileAndDecal <= decalExtents.magnitude * this.decalSizeContribution)
                            {
                                this.coveredTiles[localPosition] = true;
                            }
                        }
                    }
                }
            }

            var coveredTileCount = this.coveredTiles
                .Count(kvp => kvp.Value == true);
            var totalTileCount = this.coveredTiles.Count;
                
            return (float)coveredTileCount / totalTileCount;
        }
        
        private void OnDecalRegistered(GameObject obj)
        {
            this.Coverage = this.CalculateDecalCoverageArea();
        }
    }
}
