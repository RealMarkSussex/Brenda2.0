<template>
  <div class="home">
    <SkillsTable></SkillsTable>
  </div>
</template>

<script>
// @ is an alias to /src
import SkillsTable from '@/components/SkillsTable.vue'

export default {
  name: 'Home',
  components: {
    SkillsTable,
    
  }
}
</script>
