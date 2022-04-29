/**
 * @generated SignedSource<<d5ac9d9c3a508f767a248d969a826d86>>
 * @lightSyntaxTransform
 * @nogrep
 */

/* tslint:disable */
/* eslint-disable */
// @ts-nocheck

import { ConcreteRequest, Mutation } from 'relay-runtime';
export type CreateUserMutation$variables = {
  username: string;
};
export type CreateUserMutation$data = {
  readonly createUser: {
    readonly id: any;
    readonly name: string;
  } | null;
};
export type CreateUserMutation = {
  variables: CreateUserMutation$variables;
  response: CreateUserMutation$data;
};

const node: ConcreteRequest = (function(){
var v0 = [
  {
    "defaultValue": null,
    "kind": "LocalArgument",
    "name": "username"
  }
],
v1 = [
  {
    "alias": null,
    "args": [
      {
        "kind": "Variable",
        "name": "name",
        "variableName": "username"
      }
    ],
    "concreteType": "User",
    "kind": "LinkedField",
    "name": "createUser",
    "plural": false,
    "selections": [
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "id",
        "storageKey": null
      },
      {
        "alias": null,
        "args": null,
        "kind": "ScalarField",
        "name": "name",
        "storageKey": null
      }
    ],
    "storageKey": null
  }
];
return {
  "fragment": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Fragment",
    "metadata": null,
    "name": "CreateUserMutation",
    "selections": (v1/*: any*/),
    "type": "Mutation",
    "abstractKey": null
  },
  "kind": "Request",
  "operation": {
    "argumentDefinitions": (v0/*: any*/),
    "kind": "Operation",
    "name": "CreateUserMutation",
    "selections": (v1/*: any*/)
  },
  "params": {
    "cacheID": "589a12aff5e7de81009f527021a1382a",
    "id": null,
    "metadata": {},
    "name": "CreateUserMutation",
    "operationKind": "mutation",
    "text": "mutation CreateUserMutation(\n  $username: String!\n) {\n  createUser(name: $username) {\n    id\n    name\n  }\n}\n"
  }
};
})();

(node as any).hash = "d4318f17225e99157fb72c1ca3f81525";

export default node;
