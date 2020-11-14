using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tile : MonoBehaviour
{
	// Lists (dynamics arrays) contenant les tuiles en fonction de leurs orientations
	// On les remplis dans l'editeur
	public List<Tile> left_tiles;
	public List<Tile> right_tiles;
	public List<Tile> forward_tiles;
	public List<Tile> backward_tiles;

	public void SetColor(Color c)
	{
		// On reccupere le SpriteRenderer de l'objet pour changer la couleur du sprite
		GetComponent<SpriteRenderer>().color = c;
	}

	// Sert a visualiser, dans l'editeur, des lignes allant du centre de la tuile selectionnée vers les tuiles associées : 
	// Gauche  -> Jaune
	// Droite  -> Vert
	// Avant   -> Bleu
	// Arriere -> Rouge
	void OnDrawGizmosSelected()
	{
		foreach (Tile t in left_tiles)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.transform.position, t.transform.position + new Vector3(-.3f, .2f, 0f));
		}
		
		foreach(Tile t in right_tiles)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(this.transform.position, t.transform.position + new Vector3(.3f, -.2f, 0f));
		}
		
		foreach(Tile t in forward_tiles)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.transform.position, t.transform.position + new Vector3(-.3f, 0f, 0f));
		}
		
		foreach(Tile t in backward_tiles)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(this.transform.position, t.transform.position + new Vector3(.3f, 0f, 0f));
		}
	}
}
