using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Move : MonoBehaviour
{
	// la tuile ou se trouve le joueur
	public Tile current_tile;

	// Ces paramettres seront envoyés par les cartes a terme
	// la distance parcourue par le joueur
	public int distance;
	// Le nombre de changement de lignes
	public int shift_lane;

	// C'est pas beau, mais j'ai la flemme de reflechir a quelque chose d'elegant :
	// Je met toutes les tuiles dans cette liste dans l'editeur pour les remettre en blanc
	public List<Tile> tiles;

	// Sert a lancer la boucle recursive pour afficher les movements
	// On attache cette fonction au bouton dans l'editeur pour plus de somplicité pour les tests
	public void TestMoves()
	{
		// On remet toutes les tuiles au blanc
		foreach (Tile t in tiles)
		{
			t.SetColor(Color.white);
		}

		// On change la couleur de la tuile courrante pour la distinguer
		current_tile.SetColor(Color.magenta);
		// On lance l'algorithme pour trouver les cases ou se deplacer
		CheckMoves(distance, shift_lane, current_tile);
	}

	// Colorie les cases ou le joueur peut se deplacer
	void CheckMoves(int moves, int shift, Tile tile)
	{
		// On cherche dans toutes les tuiles qui vont vers l'avant
		// TODO : Limiter les directions

		foreach (Tile next_tile in tile.forward_tiles)
		{
			int tmp_shift = shift;
			if (tile.left_tiles.Contains(next_tile) || tile.right_tiles.Contains(next_tile))
			{
				// Si la tuile fait partie d'une autre lane et qu'on ne peux plus se deplacer de lane
				if (tmp_shift <= 0)
					// Alors on passe a la suivante
					continue;
				else
					//Sinon on dimimue le nombre de changement de lane
					tmp_shift--;

			}

			//On change la couleur de la tuile
			next_tile.SetColor(Color.grey);

			// On verifie qu'il reste du movement
			if (moves > 1)
			{
				// On relance la recherche vers a partir de cette tuile avec moins de mouvement
				CheckMoves(moves - 1, tmp_shift, next_tile);
			}

		}

	}
}
