# Mystery Web App
A sample web app running in K8s used to help illustrate debugging.

## Installation
The below command installs an app called `my-mystery-app`:

```bash
helm install --namespace example --create-namespace my-mystery-app ./charts/mystery-app
```

## Deletion
The below command deletes an app release called `my-mystery-app`:

```bash
helm uninstall --namespace example my-mystery-app
```

### Values

The following table contains the possible set of configurations and their default values.

| Path                                        | Type      | Description            | Default                         |
| ------------------------------------------- | --------- | ---------------------- | ------------------------------- |
| `image.pullPolicy`                          | `string`  | app image pull policy  | `IfNotPresent`                  |
| `image.pullSecrets`                         | `array`   | app image pull secrets | `[]`                            |
| `image.repository`                          | `string`  | app image repository   | `ghcr.io/wsugarman/mystery-app` |
| `image.tag`                                 | `string`  | app image tag          | `1.0.0`                         |

## Security

By default, the app runs as non-root in a read-only file system:

```yaml
securityContext:
  allowPrivilegeEscalation: false
  capabilities:
    drop:
    - ALL
  readOnlyRootFilesystem: true

podSecurityContext:
  runAsNonRoot: true
  seccompProfile:
    type: RuntimeDefault
```