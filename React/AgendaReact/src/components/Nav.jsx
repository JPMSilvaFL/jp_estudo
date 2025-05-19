import { Tabs } from "@mantine/core"

function Nav(){
return (
    <Tabs defaultValue="gallery">
        <Tabs.List>
            <Tabs.Tab value="user" >
                User
            </Tabs.Tab>
            <Tabs.Tab value="messages">
                Messages
            </Tabs.Tab>
            <Tabs.Tab value="settings">
                Settings
            </Tabs.Tab>
        </Tabs.List>

        <Tabs.Panel value="gallery">
            Gallery tab content
        </Tabs.Panel>

        <Tabs.Panel value="messages">
            Messages tab content
        </Tabs.Panel>

        <Tabs.Panel value="settings">
            Settings tab content
        </Tabs.Panel>
    </Tabs>
)
}
export default Nav