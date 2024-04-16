# Input system dans Unity

Unity possède une gestion des entrées de base.

Celle-ci est utilisable avec la classe [```Input```](https://docs.unity3d.com/ScriptReference/Input.html). 

Dans le menu ```Edit/Project Settings```, sous la section Input Manager, il est possible de configurer les touches par défaut su système.

![project_settings](Images/inputsystem_project_settings.png)

## Installation du nouveau Input system

Pour installer le nouveau système, il faut ouvrire le menu ```Window/Package Manager```. Dans celui-ci, sélectionner  ```Unity Registry``` dans le selecteur de type de package.

![unity_registry](Images/inputsystem_unity_registry.png)

Recherchez ensuite Input System et cliquez sur le bouton Install

![install](Images/inputsystem_install.png)

Une fois que l'installation est terminé, on vous demande si vous voulez activer le nouveau système ou garder le courant. Si on clique sur ```yes```, Unity se redémarre.

![warning](Images/inputsystem_warning.png)

Sous les paramètres du projet, il est toujours possible de spécifer un type de gestionnaire d'input ou d'accepter les deux en parallèle.

Dans le menu ```Edit/Project Settings```, dans la section ```Player```, sous le collapse ```Other Settings```, le selecteur ```Active input handling``` permet de modifier cette valeur.

![project_settings_input](Images/inputsystem_project_settings_input.png)


Dans la zone du projet, il faut ensuite créer un jeu d'action. Pour se faire, 

Cliquez avec le bouton droit sur ```Create/Input Actions```.

On peut nommer le fichier d'input actions comme on le souhaite.

![input_actions](Images/inputsystem_input_actions_file.png)

On peut double cliquer sur ce fichier pour éditer les actions :

![input_actions](Images/inputsystem_input_actions.png)

Ajouter un type de contrôleur

![add_control](Images/inputsystem_add_control.png)

Sélectionner dans la liste le type de contrôleur.

![add_control_type](Images/inputsystem_add_control_type.png)

Ajouter une action map.

Ceci permet d'avoir des groupes d'actions différents en jeu. Par exemple, un groupe d'action pour se déplacer à pied et un groupe d'action pour conduire un véhicule.

![add_control_action_map](Images/inputsystem_add_control_action_map.png)

![add_control_actions](Images/inputsystem_add_control_actions.png)

![add_control_actions](Images/inputsystem_add_control_actions-1.png)

![add_control_actions](Images/inputsystem_add_control_actions-2.png)

![add_control_actions](Images/inputsystem_add_control_actions-3.png)

![add_control_actions](Images/inputsystem_add_control_actions-4.png)

![project_path](Images/inputsystem_project_path.png)

Ajouter sur le player le Component ```Payer Input```

![player_input](Images/inputsystem_player_input.png)

Exemple de script pour le déplacement d'un personnage

```c#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody rb;

    public float moveSpeed = 1f;

    public InputActionReference move;

    private Vector3 moveDirection = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = move.action.ReadValue<Vector2>();

        moveDirection = new Vector3(direction.x, 0, direction.y);

    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * moveSpeed;
    }
}

```

![alt text](Images/inputsystem_example.png)