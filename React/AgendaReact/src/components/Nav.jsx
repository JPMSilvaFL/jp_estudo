import { Tabs } from "@mantine/core"
import User from "../pages/User.jsx";

function Nav(){
return (
    <Tabs defaultValue="gallery">
        <Tabs.List>
            <Tabs.Tab value="messages">
                Messages
            </Tabs.Tab>
            <Tabs.Tab value="settings">
                Settings
            </Tabs.Tab>
            <Tabs.Tab value="user" >
                Perfil
            </Tabs.Tab>
        </Tabs.List>


        <Tabs.Panel value="messages">
            Messages tab content
        </Tabs.Panel>

        <Tabs.Panel value="settings">
            Settings tab content
        </Tabs.Panel>

        <Tabs.Panel value="user">
            <User />
        </Tabs.Panel>
    </Tabs>
)
}
export default Nav