REST – REpresentational State Transfer
REST n’est pas un protocole comme HTTP, mais un style d’architecture qu’on utilise 
pour créer des services web simples, efficaces et évolutifs.

Il repose sur 5 contraintes principales : 
(il en existe 6 en réalité, mais 5 suffisent souvent pour comprendre l’essentiel). 
Ces contraintes rendent les applications plus modulaires, performantes et faciles à maintenir.

1 - Interface uniforme (Uniform Interface)
	But : Avoir une manière simple et unique d’accéder aux ressources,
	quel que soit le client (navigateur, appli mobile => GET PRODUCT 5)

2 - Client-Server (Client-Serveur)
	But : Séparer le client (qui demande des données) du serveur (qui les fournit).
	Cela permet de faire évoluer les deux indépendamment, 
	par exemple en changeant l’interface utilisateur sans toucher au serveur.

3 - Stateless (Sans état)
	But : Chaque requête du client doit contenir toutes les infos nécessaires pour être traitée.
	Le serveur ne garde pas d’état entre les requêtes, ce qui le rend plus simple et scalable.

4 - Cacheable (Cacheable)
	But : Les réponses du serveur peuvent être mises en cache pour améliorer les performances.
	Le client peut réutiliser les données sans avoir à refaire une requête.


5 - Système en couches (Layered System)
	But : L’architecture peut être composée de plusieurs couches (serveurs, proxys, etc.)
	Chaque couche peut être indépendante, ce qui permet de mieux gérer la charge et la sécurité.



	Exemple de fonctionnement d’une API REST :
	1. Le client envoie une requête HTTP GET à l’URL d’une ressource (par exemple, un article).
	2. Le serveur traite la requête et renvoie une réponse avec les données de l’article au format JSON ou XML.
	3. Le client peut alors afficher ces données ou les utiliser dans son application.
	4. Si le client veut modifier l’article, il envoie une requête HTTP PUT ou POST avec les nouvelles données.
	5. Le serveur met à jour l’article et renvoie une réponse de confirmation.


Terme	Signifie	                 Sert à…	                Contient l’adresse ?	Exemple
URI	    Uniform Resource Identifier	 Identifier une ressource	Pas forcément	        https://www.example.com, urn:isbn:1234
URL	    Uniform Resource Locator	 Localiser une ressource	✅ Oui	                https://google.com/search
URN	    Uniform Resource Name	     Nommer une ressource	    ❌ Non	                urn:uuid:1234-5678-9abc-def0


---------------------------------------------------------------------------------------------------------------------------------------

Status Code 


BadRequest : Retourne un code d’erreur 400

➤ Utilisé quand la requête envoyée par le client est invalide (ex : données manquantes ou mal formées).

---------------------------------------------------------------------------------------------------------------------------------------

Content : Retourne un code 200 avec des données textuelles (texte brut, HTML, JSON manuel, etc.)

➤ Utilisé pour renvoyer du contenu personnalisé.

---------------------------------------------------------------------------------------------------------------------------------------

File : Retourne un code 200 et le contenu d’un fichier

➤ Utilisé pour télécharger ou afficher un fichier (PDF, image, etc.).

---------------------------------------------------------------------------------------------------------------------------------------

Forbid : Retourne un code d’erreur 403

➤ Utilisé quand l’utilisateur est authentifié mais n’a pas les droits d’accès.

---------------------------------------------------------------------------------------------------------------------------------------

NoContent : Retourne un code 204

➤ Utilisé pour signaler que l’opération a réussi, mais qu’il n’y a rien à renvoyer.

---------------------------------------------------------------------------------------------------------------------------------------

NotFound : Retourne un code d’erreur 404

➤ Utilisé quand la ressource demandée n’existe pas.

---------------------------------------------------------------------------------------------------------------------------------------

Ok : Retourne un code 200

➤ Utilisé pour signaler le succès et retourner une donnée.

---------------------------------------------------------------------------------------------------------------------------------------

StatusCode : Permet de retourner n’importe quel code HTTP

➤ Utilisé pour renvoyer un code particulier, comme 500, 409, etc.

---------------------------------------------------------------------------------------------------------------------------------------

Unauthorized : Retourne un code d’erreur 401

➤ Utilisé quand l’utilisateur n’est pas authentifié (il doit se connecter).

---------------------------------------------------------------------------------------------------------------------------------------

