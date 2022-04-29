import { useMutation } from 'react-relay'
import { graphql } from 'babel-plugin-relay/macro'

function CreateUser() {
  const [command, success] = useMutation(graphql`
    mutation CreateUserMutation($username: String!) {
      createUser(name: $username) {
        id
        name
      }
    }
  `)

  const createUser = () =>
    command({
      variables: {
        username: 'asdf',
      },
    })

  return (
    <div className="CreateUser">
      <button style={{ float: 'right' }} onClick={createUser}>
        Create User
      </button>
    </div>
  )
}

export default CreateUser
