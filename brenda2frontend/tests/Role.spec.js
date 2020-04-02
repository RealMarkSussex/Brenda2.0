import { shallowMount } from "@vue/test-utils";
import Role from "@/components/Role.vue";

describe("Role.vue", () => {
  test("is a Vue instance", () => {
    const wrapper = shallowMount(Role, {
      propsData: {
        roleId: 1
      }
    });
    expect(wrapper.isVueInstance()).toBeTruthy();
  });
});

describe("Role.vue", () => {
    test("Correctly passes in prop", async () => {
      const wrapper = shallowMount(Role, {
        propsData: {
          roleId: 1
        }
      });
      expect(wrapper.find("label").text()).toBe("Trainee Software Engineer");
    });
  });
